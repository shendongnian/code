    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            var button = new Button
            {
                ID = "Button" + i,
                CommandArgument = i.ToString(),
                Text = "Submit" + i
            };
            button.Command += Load_Items;
            PlaceHolder1.Controls.Add(button);
        }
    }
    
    private void Load_Items(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        // Do something with id
    }
