    List<ListItem> mySelectedItems  = entities.User
           .Where(x => SelectedItems.Contains(x.ID))
           .Select(x => new ListItem { Text = x.DISPLAY_NAME, Value = x.ID })
           .ToList<ListItem>();
    foreach(ListItem item in mySelectedItems)
    {
        lstSelected.Items.Add(item);
    }
    lstSelected.DataBind();
