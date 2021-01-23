    var context = new PrincipalContext(ContextType.Domain, "YOUR_DOMAIN_NAME");
    using (var searcher = new PrincipalSearcher())
    {
        var groupName = "YourGroup";
        var sp = new GroupPrincipal(context, groupName);
        searcher.QueryFilter = sp;
        var group = searcher.FindOne() as GroupPrincipal;
        if (group == null)
            Console.WriteLine("Invalid Group Name: {0}", groupName);
        foreach (var f in group.GetMembers())
        {
            var principal = f as UserPrincipal;
            if (principal == null || string.IsNullOrEmpty(principal.Name))
                continue;
            Console.WriteLine("{0}", principal.Name);
        }
    }
