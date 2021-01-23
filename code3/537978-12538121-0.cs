    public abstract class CustomWebViewPage : WebViewPage
    {
        public ContentVersionHelper ContentVersion { get; set; }
        public override void InitHelpers()
        {
            base.InitHelpers();
            ContentVersion = new ContentVersionHelper(base.ViewContext, this);
        }
    }
    public abstract class CustomWebViewPage<TModel> : WebViewPage<TModel>
        where TModel : class
    {
        public ContentVersionHelper<TModel> ContentVersion { get; set; }
        public override void InitHelpers()
        {
            base.InitHelpers();
            ContentVersion = new ContentVersionHelper<TModel>(base.ViewContext, this);
        }
    }
