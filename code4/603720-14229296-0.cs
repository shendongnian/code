    var timer = new System.Threading.Timer((o) =>
    {
        Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
        {
            // do stuff WPF UI safe
        });
    
    }, null, 0, 60000);
