    protected void theme5_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
      if (String.Equals(e.CommandName, "YOUR_COMMAND_NAME"))
      {
       string arg = e.CommandArgument; // do whatever you want
       ListViewDataItem dataItem = (ListViewDataItem)e.Item;
       
     }
    }
