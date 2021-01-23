    if (!Application.Current.Dispatcher.CheckAccess())
    {
        Application.Current.Dispatcher.BeginInvoke(
            new Action(() => { YourMethod(); }),
            DispatcherPriority.ApplicationIdle,
            null);
    }
    else
    {
        YourMethod(); 
    }
