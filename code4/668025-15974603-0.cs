    private Page1 page1;
    private void btnShowFrame(object sender, RoutedEventArgs e)
    {
        if (page1 == null)
        {
            page1 = new Page1();
            frame1.Navigate(page1);
        }
        if (page1.Visibility != System.Windows.Visibility.Visible) page1.Visibility = System.Windows.Visibility.Visible;
    }
