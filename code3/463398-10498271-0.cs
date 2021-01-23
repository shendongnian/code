    public static MenuStrip CreateMenu(string rootDirectoryPath)
    {
        var dir = new DirectoryInfo(rootDirectoryPath);
        var menu = new MenuStrip();
        var root = new ToolStripMenuItem(dir.Name);
        menu.Items.Add(root);
        AddItems(root, dir);
        return menu;
    }
    private static void AddItems(ToolStripDropDownItem parent, DirectoryInfo dir)
    {
        foreach (var subDir in dir.GetDirectories())
        {
            AddItems((ToolStripMenuItem)parent.DropDownItems.Add(subDir.Name), subDir);
        }
    }
