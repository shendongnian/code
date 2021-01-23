    private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
                
        if (e.IsIntermediate.Equals(false))
        {
             watchTrailerWebView.Visibility = Windows.UI.Xaml.Visibility.Visible;
             Rect1.Fill = new SolidColorBrush(Windows.UI.Colors.Transparent);        
        }
        else if (e.IsIntermediate.Equals(true))
        {
             if (Rect1.Visibility == Windows.UI.Xaml.Visibility.Visible)
             {
                 WebViewBrush b = new WebViewBrush();
                 b.SourceName = "watchTrailerView";
                 b.Redraw();
                 Rect1.Fill = b;
                 watchTrailerWebView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;                   
              }
    
         }            
     }
