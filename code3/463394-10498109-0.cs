    public void BuildMenu()
    {
        DirectoryInfo dir = new DirectoryInfo(@"C:\MyRootFolder\");//Change this
        ToolStripMenuItem root = GetMenuItem(dir);
        menuStrip1.Items.Add(root);
    }
    public ToolStripMenuItem GetMenuItem(DirectoryInfo directory)
    {
        ToolStripMenuItem item = new ToolStripMenuItem(directory.Name);
        foreach (DirectoryInfo dir in directory.GetDirectories())
        {
            item.DropDownItems.Add(GetMenuItem(dir));
        }
        return item;
    }
