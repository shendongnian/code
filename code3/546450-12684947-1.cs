    private void OnScrollViewerViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        var verticalOffset = sv.VerticalOffset;
        var maxVerticalOffset = sv.ExtentHeight - sv.ViewportHeight;
        if (verticalOffset == maxVerticalOffset)
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
