     private void checkBox1_CheckStateChanged(object sender, RoutedEventArgs e)
        {
            if (checkBox1.Checked)
            {
                grid1.Visibility = System.Windows.Visibility.Hidden;
            }else
            {
                grid1.Visibility = System.Windows.Visibility.Visible;
            }
                   
        }
