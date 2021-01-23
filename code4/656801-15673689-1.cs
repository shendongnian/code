    public class Global: System.Web.HttpApplication {
        //...
        #region protected void Application_Start(...)
        protected void Application_Start(object sender, EventArgs e) {
            Williablog.Core.Configuration.ConfigSystem .Install();
            //...
        }
        #endregion
        //...
    }
