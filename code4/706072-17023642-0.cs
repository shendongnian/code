     public event EventHandler ButtonClickDemo;
    protected void Button1_Click(object sender, EventArgs e)
    {
        ButtonClickDemo(sender, e);
    }
