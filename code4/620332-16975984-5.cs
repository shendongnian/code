    private void FlipViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is FlipView)
        {
            FlipView item = (FlipView)sender;
            var flipViewItem = ((FlipView)sender).ItemContainerGenerator.ContainerFromIndex(((FlipView)sender).SelectedIndex);
            var scrollViewItem = FindFirstElementInVisualTree<ScrollViewer>(flipViewItem);
            if (scrollViewItem is ScrollViewer)
            {
                ScrollViewer scroll = (ScrollViewer)scrollViewItem;
                scroll.ScrollToHorizontalOffset(0);
                scroll.ScrollToVerticalOffset(0);
                scroll.ZoomToFactor(1.0f);
            }
        }
    }
