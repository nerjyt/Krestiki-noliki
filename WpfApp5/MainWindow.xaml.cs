using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool playerCross = true;

        private void StartButton_Click(object sender, RoutedEventArgs e) 
        {
            Button[] buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }

            StartButton.Content = "Reset";

            if (!playerCross)
            {
                AI(playerCross);
            }
        }

        private void AllCenterButtons_Click(object sender, RoutedEventArgs e) 
        {
            if ((string)(sender as Button).Content == "")
            {
                if (playerCross)
                {
                    (sender as Button).Content = "X";
                }
                else
                {
                    (sender as Button).Content = "O";
                }

                bool victory = ForVictory();
                bool noTie = ForTie();

                if (victory | noTie)
                {
                    Reset();
                }
                else
                {
                    AI(playerCross);
                    victory = ForVictory();
                    noTie = ForTie();
                }
            }
        }

        Random random = new Random();

        private void AI(bool playerCross) 
        {
            Button[] buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };
            int stop = 0;

            do
            {
                int choice = random.Next(buttons.Length);

                if ((string)buttons[choice].Content == "")
                {
                    if (playerCross)
                    {
                        buttons[choice].Content = "O";
                    }
                    else
                    {
                        buttons[choice].Content = "X";
                    }

                    break;
                }

                stop++;

            } while (stop <= 10);
        }

        private bool ForVictory() 
        {
            Button[] buttons = new Button[] { StartButton, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            bool victory = false;

            for (int i = 0; i < 7; i += 3)
            {
                if (buttons[1 + i].Content == buttons[2 + i].Content & buttons[2 + i].Content == buttons[3 + i].Content & ((string)buttons[1 + i].Content == "O" | (string)buttons[1 + i].Content == "X"))
                {
                    victory = true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (buttons[1 + i].Content == buttons[4 + i].Content & buttons[4 + i].Content == buttons[7 + i].Content & ((string)buttons[1 + i].Content == "O" | (string)buttons[1 + i].Content == "X"))
                {
                    victory = true;
                }
            }

            if (buttons[1].Content == buttons[5].Content & buttons[5].Content == buttons[9].Content & ((string)buttons[1].Content == "O" | (string)buttons[1].Content == "X"))
            {
                victory = true;
            }

            if (buttons[3].Content == buttons[5].Content & buttons[5].Content == buttons[7].Content & ((string)buttons[3].Content == "O" | (string)buttons[3].Content == "X"))
            {
                victory = true;
            }

            return victory;
        }

        private bool ForTie()
        {
            Button[] buttons = new Button[] { StartButton, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            bool noTie = true;

            foreach (Button button in buttons)
            {
                if ((string)button.Content == "")
                {
                    noTie = false; break;
                }
            }

            return noTie;
        }

        private void Reset()
        {
            Button[] buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }

            StartButton.Content = "Start";

            if (playerCross) { playerCross = false; }
            else { playerCross = true; }
        }
    }
}