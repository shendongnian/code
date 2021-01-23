    public abstract class CustomViewPage<TModel> : WebViewPage<TModel>
    {
        public override void ExecutePageHierarchy()
        {
            Output.Write("Before");
            base.ExecutePageHierarchy();
            Output.Write("After");
        }
    }
