    using (var mutex = new Mutex(false, mutexName))
    {
        if (mutex.WaitOne(0, false))
        {
            base.OnStartup(e);
        }
        else
        {
            MessageBox.Show("app is already open", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            Current.Shutdown();
        }
    }
