    using System;
    using System.Windows.Threading;
    
    namespace WpfUtility
    {
        public static class DispatcherExtension
        {
            public static void InvokeIfRequired(this Dispatcher dispatcher, Action action)
            {
                if (dispatcher == null)
                {
                    return;
                }
                if (!dispatcher.CheckAccess())
                {
                    dispatcher.Invoke(action, DispatcherPriority.ContextIdle);
                    return;
                }
                action();
            }
        }
    }
