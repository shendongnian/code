    protected void Page_Load(object sender, EventArgs e)
    {
        var button = new Button
        {
            ID = "Button1", 
            CommandArgument = "1", 
            Text = "Submit"
        };
        button.Command += Load_Items;
        PlaceHolder1.Controls.Add(button);
    }
    
    private void Load_Items(object sender, CommandEventArgs e)
    {
        // Do something
    }
