    public class MvcApplication : HttpApplication
    {
        // usual stuff here...
        protected void Application_Error(object sender, EventArgs e)
        {
            Server.HandleError(((MvcApplication)sender).Context);
        }
    }
