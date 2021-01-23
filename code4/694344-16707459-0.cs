    this.Dispatcher.Invoke(DispatcherPriority.Normal,
    (Action)delegate() 
    {
        MainWindow Mw = new MainWindow();
        // Mw.ShowDialog(); I changed this line because it cannot be a dialog here.
        Mw.Show();
        this.Close();
    });
