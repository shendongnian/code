     private void Option1_OnClick(object sender, RoutedEventArgs e)
        {
            Image.Visibility = Visibility.Collapsed;
        }
        private void Option2_OnClick(object sender, RoutedEventArgs e)
        {
            Image.Visibility = Visibility.Collapsed;
            Text4.Visibility = Visibility.Collapsed;
        }
        private void Option3_OnClick(object sender, RoutedEventArgs e)
        {
            Image.Visibility = Visibility.Collapsed;
            Text4.Visibility = Visibility.Collapsed;
            Text3.Visibility = Visibility.Collapsed;
            Text2.Visibility = Visibility.Collapsed;
        }
        private void Full_OnClick(object sender, RoutedEventArgs e)
        {
            Image.Visibility = Visibility.Visible;
            Text4.Visibility = Visibility.Visible;
            Text3.Visibility = Visibility.Visible;
            Text2.Visibility = Visibility.Visible;
        }
    
