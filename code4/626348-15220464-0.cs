    void RemoveGroup(string groupName)
    {
        string path = string.Format("WinNT://domain/myServer/{0}", groupName);
        using (DirectoryEntry entry = new DirectoryEntry(path, @"domain\serviceAccount", @"********"))
        {
            using (DirectoryEntry parent = rootEntry.Parent)
            {
                parent.Children.Remove(entry);
            }
        }
    }
