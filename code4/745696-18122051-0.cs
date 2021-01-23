    private void heavyWork()
    {
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(DisableUI));
        //rest of method
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(EnableUI));
    }
