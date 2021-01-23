    var contextMenu = new ContextMenu();
    var itemOne = new MenuItem("New");
    itemOne.Click += ContextMenuItemClick;
    contextMenu.MenuItems.Add(itemOne);
    var itemTwo = new MenuItem("Close");
    itemTwo.Click += ContextMenuItemClick;    
    contextMenu.MenuItems.Add(itemTwo);
    ContextMenu = contextMenu;
