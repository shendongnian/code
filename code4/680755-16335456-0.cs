    Console.WriteLine("login view class");
    var webView = new UIWebView(this.View.Frame);
    this.View.Add(webView);
    NSUrl url = new NSUrl("http://deekor.com"); 
    NSUrlRequest request = new NSUrlRequest(url);
    webView.LoadRequest(request);
