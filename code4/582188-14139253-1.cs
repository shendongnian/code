    public abstract class WebViewPage<T> : System.Web.Mvc.WebViewPage<T>
    {
        public override string Layout
        {
            get
            {
                return base.Layout;
            }
            set
            {
                NinjectRazorViewEngine viewEngine = new NinjectRazorViewEngine();
                System.Web.Mvc.ViewEngineResult engineResult = viewEngine.FindView(this.ViewContext.Controller.ControllerContext, value, string.Empty, true);
                System.Web.Mvc.RazorView razorView = engineResult.View as System.Web.Mvc.RazorView;
                if (razorView == null)
                {
                    string searchedIn = "";
                    foreach (string item in engineResult.SearchedLocations)
                    {
                        searchedIn += item + "\n";
                    }
                    throw new HttpException(500, "Could not find views in locations:\n" + searchedIn);
                }
                base.Layout = razorView.ViewPath;
            }
        }
    }
