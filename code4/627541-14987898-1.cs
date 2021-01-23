    public Form1()
    {
        InitializeComponent();
        List<IMenu> menuItems = new List<IMenu>() { new UpdateMenuItems(), new MenuItem(), new MenuItem2() };
        MergeMenus(this.menuStrip1.Items, menuItems.Select(m => m.ToolStripItem));
    }
    /// <summary>
    /// Recursive function that merges two ToolStripItem trees into one
    /// </summary>
    /// <param name="existingItems">Collection of exisiting ToolStripItems</param>
    /// <param name="newItems">Collection of new ToolStripItems. IEnumerable instead of ToolStripItemCollection to allow for items without an owner</param>
    private void MergeMenus(ToolStripItemCollection existingItems, IEnumerable<ToolStripItem> newItems)
    {
        int count = newItems.Count();
        int removedFromCollection = 0; // keep track of items that are removed from the newItems collection 
        for (int i = 0; i < count; i++)
        {
            ToolStripItem newItem = newItems.ElementAt(i - removedFromCollection);
            bool merged = false;
            string key = newItem.Name; // the items are identified and compared by its name
            if (existingItems.ContainsKey(key))
            {
                ToolStripItem existingItem = existingItems[key];
                if (existingItem != null && existingItem.GetType().Equals(newItem.GetType()))
                {
                    // check if the matching items are ToolStripMenuItems. if so, merge their children recursively
                    if (newItem is ToolStripMenuItem)
                        MergeMenus(((ToolStripMenuItem)existingItem).DropDownItems, ((ToolStripMenuItem)newItem).DropDownItems.Cast<ToolStripItem>());
                    // do not add this particular item (existing item with same name and type found)
                    merged = true;
                }
            }
            if (!merged) // newItem does not exist in existingItems (or not as the same type)
            {
                // if there was an owner, the item will be removed from the collection and the next element's index needs to be adjusted
                if (newItem.Owner != null) 
                    removedFromCollection++;
                // add to the 
                existingItems.Add(newItem);
            }
        }
    }
