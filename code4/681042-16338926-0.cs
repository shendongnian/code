    foreach (ListItem li in lstCatID.Items)
    {
        if (li.Selected == true)
        {
           // you are always using lstCatID.SelectedItem.Value.
            CatID += lstCatID.SelectedItem.Value + ",";
        }
    }
