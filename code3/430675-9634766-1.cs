    private ScrollViewer _scroller;
    private void ScrollViewer_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        _scroller = sender as ScrollViewer;
    }
    private void SomeMethod()
    {
        _scroller.ScrollToVerticalOffset(200d);
    }
