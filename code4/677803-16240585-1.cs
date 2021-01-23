    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        // Check if the database needs to be updated; if yes, show the corresponding window as a dialog
        var limit = CheckLimit();
        if (limit.UL == null && limit.LL == null)
        {
            var limitWindow = new LimitWindow();
            var dialogResult = limitWindow.ShowDialog();
            if (dialogResult)
            {
                // Update your database here
            }
        }
        
        // Show the actual main window of the application after the check
        this.MainWindow = new MainWindow();
        this.MainWindow.Show();
    }
