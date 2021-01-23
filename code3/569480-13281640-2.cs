    public void UpdateStatusBar(string status)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                UpdateStatusBar(status);
            });
        }
        else
        {
            toolStripStatusLabel1.Text = status;
        }
    }
