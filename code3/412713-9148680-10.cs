    public abstract class MyWebViewPage<T> : WebViewPage<T>
    {
        public override void InitHelpers()
        {
            base.InitHelpers();
            Text = new TextHelper(ViewContext);
        }
        public TextHelper Text { get; private set; }
    }
