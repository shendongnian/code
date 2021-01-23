    public class MyPlgugin : IPlugin
    {
        static MyPlugin()
        {
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
        }
    
        static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            MyErrorLogger.WriteLine("FirstChanceException event raised in {0}: {1}",
                AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
        }
    }
