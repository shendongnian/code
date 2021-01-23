    abstract public class CxWebView<T> : WebViewPage<T>
    {
        /* all of the methods & properties I want available in every view */
    }
    
    abstract public class CxWebView : CxWebView<dynamic>
    {
    }
