    //create webview and rectangle
    <WebView x:Name="WebView6" /> 
    <Rectangle x:Name="Rect1"/> 
    //put content in the webview
    protected override void OnNavigatedTo(NavigationEventArgs e) 
    { 
 
        // Ensure that our Rectangle used to simulate the WebView is not shown initially 
        Rect1.Visibility = Windows.UI.Xaml.Visibility.Collapsed; 
 
        WebView6.Navigate(new Uri("http://www.bing.com")); 
    }
    //make the rectangle visible when you want something over the top of the web content
    Rect1.Visibility = Windows.UI.Xaml.Visibility.Visible;
    //if the rectangle is visible, then hit the webview and put the content in the webviewbrush
    if (Rect1.Visibility == Windows.UI.Xaml.Visibility.Visible) 
    { 
        WebViewBrush b = new WebViewBrush(); 
        b.SourceName = "WebView6"; 
        b.Redraw(); 
        Rect1.Fill = b; 
        WebView6.Visibility = Windows.UI.Xaml.Visibility.Collapsed; 
    } 
