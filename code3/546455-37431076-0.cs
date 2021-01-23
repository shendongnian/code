    <ScrollViewer Name="scroll" ViewChanged="scroll_ViewChanged">
        <ListView />
    </ScrollViewer>
    private void scroll_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        var scrollViewer = (ScrollViewer)sender;
        if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
            btnNewUpdates.Visibility = Visibility.Visible;
    }
    private void btnNewUpdates_Click(object sender, RoutedEventArgs e)
    {
        itemGridView.ScrollIntoView(itemGridView.Items[0]);
        btnNewUpdates.Visibility = Visibility.Collapsed;
    }
