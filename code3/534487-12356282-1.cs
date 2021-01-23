    List<string> menuItems = LoadUserMenuItems();
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Dock = DockStyle.Fill;
            foreach (var menuItem in menuItems)
            {
                MenuItem item = new MenuItem(menuItem);
                item.Text = menuItem;
                item.Click += new EventHandler(item_Click);// item_click is event handler name
                // item.MenuItems.Add(); you could use this to add sub items
            }
            panel1.Controls.Add(menu);
