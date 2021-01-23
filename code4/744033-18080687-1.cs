    // Create ContextMenu
    contextMenu = new ContextMenu();
    contextMenu.Closing += contextMenu_Closing;
    // Exit item
    MenuItem menuItemExit = new MenuItem
    {
          Header = Cultures.Resources.Exit,
          Icon= Cultures.Resources.close
    };
    menuItemExit.Click += (o, a) =>
    {
         Close();
    }
    // Restore item
    MenuItem menuItemRestore = new MenuItem
    {
        Header = Cultures.Resources.Restore,
        Icon= Cultures.Resources.restore1
    };
    menuItemRestore.Click += (o, a) =>
    {
         WindowState = WindowState.Normal;
    };
    contextMenu.Items.Add(menuItemRestore);
    contextMenu.Items.Add(menuItemExit);               
    myObject.ContextMenu = contextMenu;
