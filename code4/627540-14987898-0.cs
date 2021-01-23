    List<IMenu> MenuItems = new List<IMenu>() { new UpdateMenuItems(), new MenuItem() };
    foreach (var item in MenuItems)
    {
        bool merged = false;
        string key = item.ToolStripItem.Name;
        if (this.menuStrip1.Items.ContainsKey(key)) // does item with the same name exist?
        {
            ToolStripMenuItem existingItem = this.menuStrip1.Items[key] as ToolStripMenuItem;
            if (existingItem != null)
            {
                int count = item.ToolStripItem.DropDownItems.Count;
                for (int i = 0; i < count; i++)
                {
                    existingItem.DropDownItems.Add(item.ToolStripItem.DropDownItems[0]); // switching parent, both collections are changed
                }
                //existingItem.DropDownItems.AddRange(item.ToolStripItem.DropDownItems); // index out of range exception 
                merged = true;
            }
        }
        if (!merged) // add normally if it wasn't merged into an existing item
            this.menuStrip1.Items.Add(item.ToolStripItem);
    }
