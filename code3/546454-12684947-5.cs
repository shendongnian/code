    private void OnScrollViewerViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        var verticalOffset = sv.VerticalOffset;
        var maxVerticalOffset = sv.ScrollableHeight; //sv.ExtentHeight - sv.ViewportHeight;
        if (maxVerticalOffset < 0 ||
            verticalOffset == maxVerticalOffset)
        {
            // Scrolled to bottom
            rect.Fill = new SolidColorBrush(Colors.Red);
        }
        else
        {
            // Not scrolled to bottom
            rect.Fill = new SolidColorBrush(Colors.Yellow);
        }
    }
