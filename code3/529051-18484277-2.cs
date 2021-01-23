         private void mainWinFrame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource is Button)
                {
                    Button btn = (Button)e.OriginalSource;
                    if ((btn.CommandParameter != null) && (btn.CommandParameter.Equals("Order")))
                    {
                        
                        mainWinFrame.Navigate(OrderPage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
