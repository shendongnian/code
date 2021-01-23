    public void CreateMenuCommands(ToolStripMenuItem menuItem)
    {
        menuItem.DropDownItems.Insert(0, new ToolStripMenuItem("&New", null, MenuNew_Click, Keys.Control|Keys.N));
        menuItem.DropDownItems.Insert(1, new ToolStripMenuItem("&Open...", null, MenuOpen_Click, Keys.Control | Keys.O));
        menuItem.DropDownItems.Insert(2, new ToolStripMenuItem("&Save", null, MenuSave_Click, Keys.Control | Keys.S));
        menuItem.DropDownItems.Insert(3, new ToolStripMenuItem("Save &As...", null, MenuSaveAs_Click));
    }
