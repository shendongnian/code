    foreach (RepeaterItem item in RepeatInformation.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            TextBox textBox = (TextBox)item.FindControl("TextBox1");
    
            //Now you have your textbox to do with what you like
            //You can access the .Text property to find the new value that needs saving to the database
        }
    }
