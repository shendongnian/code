    LoadingWindow _loadingWindow;
    void ShowLoadingWindow()
    {
        if (_loadingWindow == null)
            _loadingWindow = new LoadingWindow();
        _loadingWindow.Show();
    }
    void HideLoadingWindow()
    {
        if (_loadingWindow != null)
        {
             _loadingWindow.Close();
             _loadingWindow.Dispose();
        }
    }
    void LoadSomething()
    {
        while (...)
        {
            // busy code goes here
        }
        // after code is finished, close the form
        MethodInvoker closeForm = delegate { HideLoadingWindow(); };
        _loadingWindow.Invoke(closeForm);
    }
    public MainWindow()
    {
        ShowLoadingWindow();
        new Thread(LoadSomething).Start();
    }
    }
