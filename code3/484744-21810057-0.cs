    class WebViewClientCallback : WebViewClient
    {
        public event EventHandler PageLoaded = delegate { };
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            PageLoaded(this, EventArgs.Empty);
        }
     
    }
