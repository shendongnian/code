    private void YourClassName_OnLoaded(object sender, System.Windows.RoutedEventArgs e)
    {
        this.testTextBlock.Visibility = Visibility.Collapsed;
    }
    private void TestButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.testTextBlock.Visibility = Visibility.Visible;
    }
