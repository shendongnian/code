    public void MyEventMethod(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        this.TextBox1.Text = btn.CommandArgument;
    }
