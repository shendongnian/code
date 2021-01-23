    private void Button_Click(object sender, RoutedEventArgs e)
    {
         Button button1 = (Button)sender;
         NavigationService.Navigate(new System.Uri(button1.Tag.ToString()));
    }
