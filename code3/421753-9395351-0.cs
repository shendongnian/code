    private void button1_Click(object sender, EventArgs e)
    {
        OnClosing(null);
    }
    protected override void OnClosing(CancelEventArgs e)
    {
        if (e == null)
        {
            // Raise your Message or Cancel
            this.Close();
        }
        else
        {
            base.OnClosing(e);
        }
    }
