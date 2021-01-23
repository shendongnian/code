    this.tGID.GotFocus += OnFocus;
    this.tGID.LostFocus += OnDefocus;
    private void OnFocus(object sender, EventArgs e)
    {
       MessageBox.Show("Got focus.");
    }
    private void OnDefocus(object sender, EventArgs e)
    {
        MessageBox.Show("Lost focus.");
    }
