    public static class DispatcherEx
    {
        public static void InvokeOrExecute(this Dispatcher dispatcher, Action action)
        {
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                       action);
            }
        }
    }
