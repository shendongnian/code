    var itemsToRemove = new List<ListViewItem>();
    
    for (int intCount = 0; intCount < lvEmpDetails.SelectedItems.Count; intCount++)
    {
         lbxEmpName.Items.Add(lvEmpDetails.SelectedItems[intCount].Text);  
         itemsToRemove.Add(lvEmpDetails.SelectedItems[intCount]);
    }
    
    foreach (var item in itemsToRemove)
    {
        item.Remove();                  
    }
