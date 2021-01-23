    foreach (object ob in (IEnumerable)obGroups)
    {
        // Create object for each group.
        DirectoryEntry obGpEntry = new DirectoryEntry(ob);
        if (obGpEntry.Path.toLower().contains("OU=Security Groups")) {
            groups.Add(obGpEntry.Name);
        }
    }
