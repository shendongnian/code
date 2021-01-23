    protected void MyButtonHandler(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if (b != Null)
        {
           string cmdName = b.CommandName;
           // logic based on cmdName
        }
    }
