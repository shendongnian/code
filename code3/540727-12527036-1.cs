    foreach (object ob in (IEnumerable)obGroups)
    {
        // Create object for each group.
        DirectoryEntry obGpEntry = new DirectoryEntry(ob);
        if (obGpEntry.Path.ToLower().contains("ou=security groups")) {
            groups.Add(obGpEntry.Name);
        }
    }
