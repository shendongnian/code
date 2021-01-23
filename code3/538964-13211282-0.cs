    public class SmartDispatcher
    {
        public static void BeginInvoke(Action action)
        {
            if (Deployment.Current.Dispatcher.CheckAccess()
                || DesignerProperties.IsInDesignTool)
            {
                action();
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(action);
            }
        }
    }
