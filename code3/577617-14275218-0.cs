    public static ArrayList GetAllActiveDirectoryUsersByDisplayName(string dc) 
                {
                    ArrayList list = new ArrayList();
        
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dc);
                    UserPrincipal u = new UserPrincipal(ctx);
        
                    PrincipalSearcher ps = new PrincipalSearcher(u);
                    PrincipalSearchResult<Principal> results = ps.FindAll();
        
                    foreach (UserPrincipal usr in results)
                    {
                        list.Add(usr.Name);
                    }
    
                list.Sort();
    
                return list; 
            }
