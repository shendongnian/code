    public abstract class MyWebViewPage<T> : WebViewPage<T>
    {
        public MyWebViewPage()
        {
            Text = new TextHelper();
        }
        public TextHelper Text { get; private set; }
    }
