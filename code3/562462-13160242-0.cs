    private void AppBar_Opened(object sender, object e)
    {
        WebViewBrush wvb = new WebViewBrush();
        wvb.SourceName = "contentView";
        wvb.Redraw();
        contentViewRect.Fill = wvb;
        contentView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;     
    }
    
    private void AppBar_Closed(object sender, object e)
    {
        contentView.Visibility = Windows.UI.Xaml.Visibility.Visible;
        contentViewRect.Fill = new SolidColorBrush(Windows.UI.Colors.Transparent);
    }
