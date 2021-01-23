    List<ListItem> itemsToDelete=new List<ListItem>();
     foreach (ListItem li in AdvLst.Items)
                {
                    if (li.Selected == true)
                    {
                        SelectedMortLst.Items.Add(AdvLst.SelectedItem);
                        itemsToDelete.Add(AdvLst.SelectedItem);
    //                    AdvLst.Items.Remove(AdvLst.SelectedItem);
                    }
    
                }
    
    foreach(ListItem item in itemsToDelete)
    {
    AdvLst.Items.Remove(item);
    }
