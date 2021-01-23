Code behind
    private void Up_Click(object sender, RoutedEventArgs e)
    {
        scrollViewerChannelBtns.ScrollToVerticalOffset(scrollViewerChannelBtns.VerticalOffset - 50);
    }
    private void Down_Click(object sender, RoutedEventArgs e)
    {
        scrollViewerChannelBtns.ScrollToVerticalOffset(scrollViewerChannelBtns.VerticalOffset + 50);
    }
