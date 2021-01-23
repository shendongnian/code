    public void SetLabel(string text)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(() => label1.Text = text));
        }
        else
        {
            label1.Text = text;
        }
    }
