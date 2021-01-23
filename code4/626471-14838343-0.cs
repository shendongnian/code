    public class RootDispatcherFetcher
    {
         private static Dispatcher _rootDispatcher = null;
         public static Dispatcher RootDispatcher
         {
             get 
             {
                 _rootDispatcher = _rootDispatcher ??
                     Application.Current != null 
                         ? Application.Current.Dispatcher
                         : new Dispatcher(...);
                 return _rootDispatcher;
             }
             // unit tests can get access to this via InternalsVisibleTo
             internal set
             {
                 _rootDispatcher = value;
             }
         }
    }
