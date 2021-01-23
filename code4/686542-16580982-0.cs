    public class CustomWebViewPage : WebViewPage
    {
        public override void ExecutePageHierarchy()
        {
            if (Context.Items["__MainView"] == null)
            {
                this.Layout = String.Format("~/Views/Shared/{0}/_Layout.cshtml", ViewContext.Controller.GetType().Namespace);
                Context.Items["__MainView"] = "Not Null";
            }
            base.ExecutePageHierarchy();
        }
        public override void Execute()
        {
        }
    }
    public class CustomWebViewPage<T> : WebViewPage<T>
    {
        public override void ExecutePageHierarchy()
        {
            if (Context.Items["__MainView"] == null)
            {
                this.Layout = String.Format("~/Views/Shared/{0}/_Layout.cshtml", ViewContext.Controller.GetType().Namespace);
                Context.Items["__MainView"] = "Not Null";
            }
            base.ExecutePageHierarchy();
        }
        public override void Execute()
        {
        }
    }
    <system.web.webPages.razor>
      <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <pages pageBaseType="Mv4App.CustomWebViewPage">
