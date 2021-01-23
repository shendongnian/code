    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        ((Control)sender).Visibility = Visibility.Collapsed;
        ((Control)sender).Visibility = Visibility.Visible;
        Frame.Navigate(typeof (Page2));            
    }
