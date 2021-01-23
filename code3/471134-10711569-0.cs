    public int ComputersOnNetwork()
    {
        int count = 0;
        using (DirectoryEntry root = new DirectoryEntry("WinNT:"))
        {
            foreach (DirectoryEntry computer in root.Children)
            {
                if ((computer.Name != "Schema"))
                {
                    count++;
                }
            }
        return count;
    }
