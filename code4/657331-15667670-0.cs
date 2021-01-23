    private void BuildMenu()
    {
        List<MenuItem> menuItems = GetTopLevelMenuItems();
    
        string html = "<ul>";
    
        foreach (var menuItem in menuItems)
        {
            html += BuildMenuSubMenu(menuItem);
        }
        html += "</ul>"
    }
    
    private string BuildMenuSubMenu(MenuItem menuItem)
    {
        string html = string.Empty;
    
        List<MenuItem> childItems = GetChildItems(menuItem);
    
        html += string.Format("<li><a href=\"{0}\">{1}</a>", menuItem.Url, menuItem.MenuText);
    
        if (childItems.Count > 0)
        {
            html += "<ul>";
            foreach (var child in childItems)
            {
                html += BuildMenuSubMenu(child);
            }
            html += "<ul>";
        }
    
        html += "<li>";
    
        return html;
    }
