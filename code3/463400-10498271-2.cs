    public static MenuStrip CreateMenu(string rootDirectoryPath)
    {
        var dir = new DirectoryInfo(rootDirectoryPath);
        var menu = new MenuStrip();
        var root = new ToolStripMenuItem(dir.Name);
        var includedDirs = new List<string> {dir};
        menu.Items.Add(root);
        AddItems(root, dir, includedDirs);
        return menu;
    }
    private static void AddItems(ToolStripDropDownItem parent, DirectoryInfo dir, ICollection<string> includedDirs)
    {
        foreach (var subDir in dir.GetDirectories().Where(subDir => !includedDirs.Contains(subDir.FullName)))
        {
            includedDirs.Add(subDir.FullName);
            AddItems((ToolStripMenuItem)parent.DropDownItems.Add(subDir.Name), subDir, includedDirs);
        }
    }
