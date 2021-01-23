    var groups = new List<string>();
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    GroupPrincipal qbeGroup = new GroupPrincipal(ctx);
    PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);
        foreach (var group in srch.FindAll())
        {
           if (group.Name.Contains("Administrators") || group.Name.Contains("Users"))
           {
                 groups.Add(group.Name);
           }
        }
    return groups.ToArray();
