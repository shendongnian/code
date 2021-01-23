        void ChangePadding(object sender, RoutedEventArgs e)
        {
            if (btn11.Padding.Left == 5.0)
            {
                btn11.Padding = new Thickness(2.0);
                btn11.Content = "Control Padding changes from 5 to 2.";
            }
            else
            {
                btn11.Padding = new Thickness(5.0);
                btn11.Content = "Padding";
            }
        }
