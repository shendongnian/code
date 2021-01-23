    public class DispatcherHelper
        {
            private static Dispatcher dispatcher;
    
            public static void BeginInvoke(Action action)
            {
                if (dispatcher != null)
                {
                    dispatcher.BeginInvoke(action);
                    return;
                }
                throw new InvalidOperationException("Dispatcher must be initialized first");
            }
    
            //App.xaml.cs
            public static void RegisterDispatcher(Dispatcher dispatcher)
            {
                DispatcherHelper.dispatcher = dispatcher;
            }
        }
