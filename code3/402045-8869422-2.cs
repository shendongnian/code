    public event EventHandler Click = new delegate() { };
    public void butButton_Click(object sender, EventArgs e)
    {
        Click(sender, e);
    }
    public void lbuButton_Click(object sender, EventArgs e)
    {
        Click(sender, e);
    }
