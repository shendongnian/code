    SetContentView(Resource.Layout.webView);
    WebView webView = FindViewById<WebView>(Resource.Id.webView1);
    webView.Settings.JavaScriptEnabled = true;
    webView.LoadUrl(url);
    webView.SetWebViewClient(new dealWithWebView(this));
