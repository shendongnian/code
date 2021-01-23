    public static void DoEvents() 
    { 
        Application.Current.Dispatcher.Invoke(
        DispatcherPriority.Background,new Action(delegate { })); 
    }
