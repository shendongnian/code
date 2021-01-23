    public class BaseGlobal : HttpApplication
    {
        protected virtual void Application_Start(Object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger.Warn("Portal Started");  //I can find it log file
        }
    }
