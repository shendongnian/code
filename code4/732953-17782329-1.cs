    if (!Application.Current.Dispatcher.CheckAccess())
    {
        Application.Current.Dispatcher.BeginInvoke(
            new Action(() => { PlaceYourMethodHere(); }),
            DispatcherPriority.ApplicationIdle,
            null);
    }
    else
    {
        PlaceYourMethodHere(); 
    }
