    var itemsToRemove = new List(TabItem);
	
	foreach (object item  in mainTab.Items)
    {
      TabItem ti = (TabItem)item;
      if ("welcomeTabItem" != ti.Name)
       {
         itemsToRemove.Add(item);
       }
    }
	
	foreach (var itemToRemove in itemsToRemove)
	{
		mainTab.Items.Remove(itemToRemove);
	}
