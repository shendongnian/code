    private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Close the Waiting form.
        waitingForm.Close();
        // Retrieve the result of bg_DoWork().
        Array servers = e.Result as Array;
        bool ServersFound = false;
        foreach (string Value in servers)
        {
            this.cmbServer.Items.Add(Value);
            ServersFound = true;
        }
        if (!ServersFound)
        {
            this.cmbServer.Items.Add(Strings.Lang("ddServerNoneFound"));
            this.cmbServer.SelectedIndex = 0;
        }
        else
        {
            if (!s.empty(General.setting("SQLSERVER")))
            {
                this.cmbServer.Text = General.setting("SQLSERVER");
            }
            else
            {
                this.cmbServer.SelectedIndex = 0;
            }
        }
        this.picRefreshServers.Image = Properties.Resources.Refresh;
    }
