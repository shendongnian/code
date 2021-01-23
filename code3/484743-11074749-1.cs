    class dealWithWebView : WebViewClient
    {
        Activity parent;
        public dealWithWebView(Activity parent)
        {
            this.parent = parent;
        }
        public override void OnPageFinished(WebView view, string url)
        {
            var webView = view;
            Context c = webView.Context;
            // it goes away and does something
            // calls another method in the class which returns back here
            // all done - so finish the parent now
            parent.Finish();
        }
    }
