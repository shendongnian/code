    private delegate void UpdateStatusDelegate(string status);
    private void UpdateStatus(string status)
    {
        if (this.label1.InvokeRequired)
        {
            this.Invoke(new UpdateStatusDelegate(this.UpdateStatus), new object[] { status });
            return;
        }
        this.label1.Text = status;
    }
