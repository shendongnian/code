    private void ProcessKilled(object sender, EventArgs e)
    {
        if (this.InvokeRequired)
            this.Invoke(aKillProcess);
        else
            this.Close();
    }
    void CloseApp()
    {
       this.Close();
    }
