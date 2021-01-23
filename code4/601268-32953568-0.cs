    public static void Add(this GroupPrincipal group, Principal child)
    {
         group.Members.Add(child);
         LogFile.WriteLine("Added {0} to group", child.Name);
         //Do whatever else you have to do...
    }
