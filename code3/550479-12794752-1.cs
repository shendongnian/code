    using (DirectoryEntry objEntry = new DirectoryEntry("WinNT://Workgroup"))
    {
        foreach (DirectoryEntry objEntry in workgroup.Children)
        {
            Console.WriteLine(child.Name);
        }
    }
