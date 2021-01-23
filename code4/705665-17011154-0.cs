     private void button1_Click(object sender, RoutedEventArgs e)
            {
                button1.IsEnabled = !button1.IsEnabled;
                if (button1.IsEnabled)
                {
                    btndisbackground.Visibility = Visibility.Hidden;
                }
                else
                {
                    btndisbackground.Visibility = Visibility.Visible;
                }
            }
