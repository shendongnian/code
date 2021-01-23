    public int ComputersOnNetwork()
    {
        using (var root = new DirectoryEntry("WinNT:"))
        {
            return root.Children.Cast<DirectoryEntry>().Count(x => x.Name != "Schema");
        }
    }
