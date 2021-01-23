    public void CloseForm()
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(this.Close));
        }
        else
        {
            this.Close();
        }
    }
