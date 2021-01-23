    // Create ContextMenu
    contextMenu = new ContextMenu();
    contextMenu.Closing += contextMenu_Closing;
    // Exit item
    menuItemExit = new MenuItem
    {
          Header = Cultures.Resources.Exit,
          Icon= Cultures.Resources.close
    };
    menuItemExit.Click += menuItemExit_Click;
    // Restore item
    menuItemRestore = new MenuItem
    {
        Header = Cultures.Resources.Restore,
        Icon= Cultures.Resources.restore1
    };
    menuItemRestore.Click += menuItemRestore_Click;
    contextMenu.Items.Add(menuItemRestore);
    contextMenu.Items.Add(menuItemExit);               
    myObject.ContextMenu = contextMenu;
