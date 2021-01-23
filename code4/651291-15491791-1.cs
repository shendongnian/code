    foreach(ListItem item in lstAdded.Items)
    {
        TheItem = new clsStock();
        TheItem.AuthId = 5;
        TheItem.ItemId = Convert.ToInt32(item.Value);
        TheItem.Cancel = "false";
        Items.AddOrder(TheItem);
    }
 
