    List<MyMenuItem> MenuItems = <list of your menu items, to save db calls>
    List<MyMenuItem> GetMenu()
    {
        return MenuItems.Where(f => f.PId == null).Select(GetItem).ToList();
    }
    MyMenuItem GetItem(MyMenuItem myMenuItem)
    {
        var immidiateChildren = MenuItems.Where(m => m.PId == myMenuItem.Id);
        if (immidiateChildren.Any())
            myMenuItem.ChildItems = immidiateChildren.Select(GetItem).ToList();
        return myMenuItem;
    }
