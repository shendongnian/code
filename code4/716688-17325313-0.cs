    private void MyApp_FormClosing(object sender, FormClosingEventArgs e)
    {
        lblMainStatus.Text = "Closing app, please wait.";
        foreach(MyResource r in AppResources)
        {
            System.Threading.Thread.Sleep(1000);
            lblMinorStatus.Text = "Freeing resources - remaining : " + AppResources.Count;
            r.discard();
            this.Refresh();
        }
        lblMinorStatus.Text = "Done.";
        // And so on...
    }
