    var menu = (Menu)Master.FindControl("NavigationMenu");
    // string valuePath = @"~/About.aspx";
    string valuePath = @"Gestions/Gestion/Ajouter";
    
    var item = menu.Items.Cast<MenuItem>().FirstOrDefault(i =>
        i.NavigateUrl.Equals(valuePath, 
        StringComparison.InvariantCultureIgnoreCase));
    
    if(item != null)
    {
        if (item.Parent != null)
            item.Parent.ChildItems.Remove(item);
        else
            menu.Items.Remove(item);
    }
