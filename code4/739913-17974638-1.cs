    public void GoAsync() //no longer async as it blocks on Appication.Run
    {
        var owner = new Win32Window(Process.GetCurrentProcess().MainWindowHandle);
        _progressForm = new Form1();
    
        var progress = new Progress<int>(value => _progressForm.UpdateProgress(value));
    
        _progressForm.Activated += async (sender, args) =>
            {
                await Go(progress);
                _progressForm.Close();
            };
    
        Application.Run(_progressForm);
    }
