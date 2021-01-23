    public class MyGlobal : BaseGlobal
    {
            protected override void Application_Start(Object sender, EventArgs e)
            {
                base.Application_Start(sender,e);
    
                Logger.Warn("Portal Started 2"); // Can not find it in log file
            }
    }
