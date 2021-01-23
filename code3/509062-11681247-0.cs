    public void UpdateStatus(string data)
    {
        if (this.tbxStatus.InvokeRequired)
        {
            UpdateStatusDelegate d = new UpdateStatusDelegate(UpdateStatus);
            this.Invoke(d, new object[] { data });
        }
        else
        {
            this.tbxStatus.Text = data;
        }
    }
