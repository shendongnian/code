    private void scrollViewerLeft_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        scrollViewerMiddle.ScrollToVerticalOffset((sender as ScrollViewer).VerticalOffset);
        scrollViewerRight.ScrollToVerticalOffset((sender as ScrollViewer).VerticalOffset);
    }
    private void scrollViewerMiddle_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        scrollViewerLeft.ScrollToVerticalOffset((sender as ScrollViewer).VerticalOffset);
        scrollViewerRight.ScrollToVerticalOffset((sender as ScrollViewer).VerticalOffset);
    }
    private void scrollViewerRight_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        scrollViewerLeft.ScrollToVerticalOffset((sender as ScrollViewer).VerticalOffset);
        scrollViewerMiddle.ScrollToVerticalOffset((sender as ScrollViewer).VerticalOffset);
    }
