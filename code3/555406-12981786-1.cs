    ((DelegateCommand)OpenDatabaseCommand).RaiseCanExecuteChanged();
in the internal class Microsoft.Practices.Prism.Commands.WeakEventHandler is this method:
    public static DispatcherProxy CreateDispatcher()
    {
        DispatcherProxy proxy = null;
    #if SILVERLIGHT
        if (Deployment.Current == null)
            return null;
        proxy = new DispatcherProxy(Deployment.Current.Dispatcher);
    #else
        if (Application.Current == null)
            return null;
        proxy = new DispatcherProxy(Application.Current.Dispatcher);
    #endif
        return proxy;
    }
