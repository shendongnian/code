     private void txtNumber_KeyUp(object sender, KeyEventArgs e)
            {
                TextBox txtbox = sender as TextBox;
                if (txtbox.Text.Contains(';'))
                {
                    Dispatcher.BeginInvoke(() =>
                    { 
                        lstSelectedNumber.ItemsSource = null;
                        lstSelectedNumber.ItemsSource = lstContactModel;
                    });
                }
            }
