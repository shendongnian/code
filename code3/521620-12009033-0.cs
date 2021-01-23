    private void rb1_Checked(object sender, RoutedEventArgs e)
        {
    
            if (rb1.IsChecked == true)
            {
                this.rb2.Visibility = Visibility.Visible;
            }
            else if (rb1.IsChecked == false)
            {
               this.rb2.Visibility = Visibility.Collapsed;
            } 
