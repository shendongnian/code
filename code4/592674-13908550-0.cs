    public void doWork()
    {
        System.Threading.Thread.Sleep(10000); //Simulating your Process
        Dispatcher.BeginInvoke(new System.Threading.ThreadStart(delegate() { updateButton.IsEnabled = true; }), System.Windows.Threading.DispatcherPriority.Background);
    }
