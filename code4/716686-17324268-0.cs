    private bool _applicationReadyToExit = false;
    // ... Your project code here ...
    private void MyApp_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_applicationReadyToExit)
        {
            e.Cancel = true;
            CleanAndExit();
            return;
        }
    }
    private void CleanAndExit()
    {
        lblMainStatus.Text = "Closing app, please wait.";
        lblMainStatus.Refresh();
        foreach(MyResource r in AppResources)
        {
            lblMinorStatus.Text = "Freeing resources - remaining : " + AppResources.Count;
            lblMinorStatus.Refresh();
            r.discard();
        }
        lblMinorStatus.Text = "Done.";
        lblMinorStatus.Refresh();
        // And so on... Then close informing that we are clean
        _applicationReadyToExit = true;
        this.Close();
    }
