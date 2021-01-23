    public static void DoEvents()
    {
        if (Application.Current != null)
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
    }
    public void Foo()
    {
       button1.IsEnabled = false
       DoEvents();
       Thread.Sleep(3000);
       button1.IsEnabled = true;
       DoEvents();
       Thread.Sleep(3000);
       button1.IsEnabled = false;
    }
