    private static PrincipalContext _ctx = new PrincipalContext(ContextType.Domain, System.Configuration.ConfigurationManager.AppSettings["DomainName"]);
      public List<string> UserGroups(string userName)
      {
        List<string> ret = new List<string>();
        using (UserPrincipal user = UserPrincipal.FindByIdentity(_ctx, userName))
        {
          if (user != null)
          {
            foreach (Principal p in user.GetAuthorizationGroups())
            { 
              ret.Add(p.Name);
            }
          }
        }
        return ret;
      }
