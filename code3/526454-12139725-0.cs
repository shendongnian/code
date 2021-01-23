    ObservableCollection images = new ObservableCollection();
    TaskFactory tFactory = new TaskFactory();
    tFactory.StartNew(() =>
    {
    for (int i = 0; i < 50; i++)
    {
    //GET IMAGE Path FROM SERVER
    System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)delegate()
    {
    // UPDATE PROGRESS BAR IN UI
    });
    
    images.Add(("");
    }
    
    }).ContinueWith(t =>
    {
    if (t.IsFaulted)
    {
    // EXCEPTION IF THREAD IS FAULT
    throw t.Exception;
    }
    System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)delegate()
    {
    //PROCESS IMAGES AND DISPLAY
    });
    });
