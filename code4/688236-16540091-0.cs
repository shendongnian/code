        ContextMenu rightcontext;
        private void rtb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MenuItem[] menuItems = new MenuItem[] { new MenuItem("Cut"), new MenuItem("Copy"), new MenuItem("Paste") };
                rightcontext = new ContextMenu(menuItems);
                rightcontext.MenuItems[0].Click += contextMenuItemClick;
                rightcontext.MenuItems[1].Click += contextMenuItemClick;
                rightcontext.MenuItems[2].Click += contextMenuItemClick;
                int xOffset = Cursor.Position.X - Dte.ActiveForm.Location.X;
                int yOffset = Cursor.Position.Y - Dte.ActiveForm.Location.Y;
                rightcontext.Show(Dte.ActiveForm, new Point(xOffset, yOffset));
            }
        }
        private void contextMenuItemClick(object sender, EventArgs e)
        {
            MenuItem m = (MenuItem)(sender);
            if (m.Text.ToLower() == "copy")
            {
                // Some Code
            }
        }
