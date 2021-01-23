    List<string> menuItems = LoadUserMenuItems();// this is a method you should create something like it
                ContextMenu menu = new ContextMenu();
                foreach (var menuItem in menuItems)
                {
                    MenuItem item = new MenuItem(menuItem);
                    item.Text = menuItem;
                    item.Click += new EventHandler(item_Click);// item_click is event handler name
                }
    
                this.ContextMenu = menu;// assuming that you want the menu to the window
