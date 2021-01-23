    public class Global : System.Web.HttpApplication
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Global));
        protected void Application_Start(object sender, EventArgs e)
        {
            Log.Info("Startup application.");
        }
    }
