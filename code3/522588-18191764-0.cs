    //definition for WebViewClientAuthentication
    public class WebViewClientAuthentication : WebViewClient
    {
        public override void OnReceivedSslError(WebView view, SslErrorHandler handler, Android.Net.Http.SslError error)
        {
            handler.Proceed();
        }
    }
