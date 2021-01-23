    public abstract class MyWebViewPage<T> : WebViewPage<T>
    {
        public HtmlHelper Text()
        {
            return Html;
        }
    }
