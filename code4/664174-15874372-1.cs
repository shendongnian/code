        private void tableLayout_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Add Device"));
                m.MenuItems.Add(new MenuItem("Delete Device"));
                m.MenuItems.Add(new MenuItem("Fire"));
                m.MenuItems.Add(new MenuItem("Fault"));
                m.MenuItems.Add(new MenuItem("Suppress"));
                //add this line to the event handler
                m.Show((Control)(sender), e.Location);
            }
        }
