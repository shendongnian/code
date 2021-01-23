    private static MenuStrip CreateMenu(string rootDirectoryPath)
    {
        var dir = new DirectoryInfo(rootDirectoryPath);
        var menu = new MenuStrip();
        var root = new ToolStripMenuItem(dir.Name);
        var includedDirs = new List<DirectoryInfo> {dir};
        menu.Items.Add(root);
        AddItems(root, dir, includedDirs);
        return menu;
    }
    private static void AddItems(ToolStripDropDownItem parent, DirectoryInfo dir, ICollection<DirectoryInfo> includedDirs)
    {
        foreach (var subDir in dir.GetDirectories().Where(subDir => !includedDirs.Contains(subDir)))
        {
            includedDirs.Add(subDir);
            AddItems((ToolStripMenuItem)parent.DropDownItems.Add(subDir.Name), subDir, includedDirs);
        }
    }
