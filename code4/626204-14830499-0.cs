    protected void CommandLinkClicked(object sender, DataGridCommandEventArgs e)
    {
        var scrapId = Int32.Parse(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "like" : 
                    //do stuff
                    break;
            case "unlike" : 
                    //do stuff
                    break;
        }
    }
