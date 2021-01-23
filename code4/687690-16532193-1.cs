    private MenuItem FindItem(MenuItemCollection collection, string url)
    {
        foreach (MenuItem item in collection)
        {
            if (item.NavigateUrl.Equals(url, 
                StringComparison.InvariantCultureIgnoreCase))
                return item;
    
            if (item.ChildItems.Count > 0)
                return FindItem(item.ChildItems, url);
        }
    
        return null;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var menu = (Menu)Master.FindControl("NavigationMenu");
        // string valuePath = @"Gestions/Gestion/Ajouter";
        string valuePath = @"~/About/About2.aspx";
    
        var item = FindItem(menu.Items, valuePath);
    
        if(item != null)
        {
            if (item.Parent != null)
                item.Parent.ChildItems.Remove(item);
            else
                menu.Items.Remove(item);
        }
    }
