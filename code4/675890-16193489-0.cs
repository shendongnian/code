    protected override ContextMenuStrip CreateMenu()
    {
        //  Create the menu strip.
        var menu = new ContextMenuStrip();
 
        //  Create a 'count lines' item.
        var itemCountLines = new ToolStripMenuItem
        {
            Text = "Count Lines...",
            Image = Properties.Resources.CountLines
        };
 
        //  When we click, we'll count the lines.
        itemCountLines.Click += (sender, args) => CountLines();
 
        //  Add the item to the context menu.
        menu.Items.Add(itemCountLines);
 
        //  Return the menu.
        return menu;
    }
