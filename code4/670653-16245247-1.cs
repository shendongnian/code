    public void ListAllGroupsDomain()
    {
        ListAllGroups(ContextType.Domain, "myDomainUsername");
    }
    
    public void ListAllGroupsMachine()
    {
        ListAllGroups(ContextType.Machine, "myMachineUsername");
    }
    
    public void ListAllGroups(ContextType contextType, string userName)
    {
        using (var context = new PrincipalContext(contextType))
        {
            using (var findByIdentity = UserPrincipal.FindByIdentity(context, userName))
            {
                if (findByIdentity != null)
                {
                    var groups = findByIdentity.GetGroups(context);
                    var results = groups.Select(g => g.Name).ToArray();
                    Console.WriteLine("Listing {0} groups", results.Count());
                    foreach (var name in results)
                    {
                        Console.WriteLine("{0}", name);
                    }
                }
            }
        }
    }
