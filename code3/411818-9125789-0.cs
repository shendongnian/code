           private void menuActive(MenuStrip menus)
           {
                foreach (ToolStripMenuItem menu in menus.Items)
                {
                    activateItems(menu);
                }
            }
        
            private void activateItems(ToolStripMenuItem item)
            {
                item.Visible = true;
                for (int i = 0; i < item.DropDown.Items.Count; i++)
                {
                    ToolStripItem subItem = item.DropDown.Items[i];
                    subItem.Visible = true;
                    if (item is ToolStripMenuItem)
                    {
                        activateItems(subItem as ToolStripMenuItem);
                    }
    
                }
            }
