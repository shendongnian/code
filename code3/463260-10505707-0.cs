    static void Main(string[] args)
    {
      /* Retreiving RootDSE informations
       */
      string ldapBase = "LDAP://WM2008R2ENT:389/";
      string sFromWhere = ldapBase + "rootDSE";
      DirectoryEntry root = new DirectoryEntry(sFromWhere, "dom\\jpb", "pwd");
      string defaultNamingContext = root.Properties["defaultNamingContext"][0].ToString();
      string schemaNamingContext = root.Properties["schemaNamingContext"][0].ToString();
      string configurationNamingContext = root.Properties["configurationNamingContext"][0].ToString();
    
      /* Search the 3 domain FSMO roles
       */
      sFromWhere = ldapBase + defaultNamingContext;
      DirectoryEntry deBase = new DirectoryEntry(sFromWhere, "dom\\jpb", "pwd");
    
      DirectorySearcher dsLookForDomain = new DirectorySearcher(deBase);
      dsLookForDomain.Filter = "(fsmoRoleOwner=*)";
      dsLookForDomain.SearchScope = SearchScope.Subtree;
      dsLookForDomain.PropertiesToLoad.Add("fsmoRoleOwner");
      dsLookForDomain.PropertiesToLoad.Add("distinguishedName");
    
      SearchResultCollection srcDomains = dsLookForDomain.FindAll();
      foreach (SearchResult sr in srcDomains)
      {
        /* For each root look for the groups containing my user
         */
        string fsmoRoleOwner = sr.Properties["fsmoRoleOwner"][0].ToString();
        string distinguishedName = sr.Properties["distinguishedName"][0].ToString();
        Regex srvNameRegEx = new Regex("^CN=NTDS Settings,CN=(.*),CN=Servers,.*$");
        Match found = srvNameRegEx.Match(fsmoRoleOwner);
       
        if (distinguishedName == defaultNamingContext)
          Console.WriteLine("PDC is {0}", found.Groups[1].Value);
        else if (distinguishedName.Contains("RID Manager"))
          Console.WriteLine("RID Manager is {0}", found.Groups[1].Value);
        else
          Console.WriteLine("Infrastructure Manager is {0}", found.Groups[1].Value);
      }
    
      /* Search the schema FSMO role
      */
      sFromWhere = ldapBase + schemaNamingContext;
      deBase = new DirectoryEntry(sFromWhere, "dom\\jpb", "pwd");
    
      dsLookForDomain = new DirectorySearcher(deBase);
      dsLookForDomain.Filter = "(fsmoRoleOwner=*)";
      dsLookForDomain.SearchScope = SearchScope.Subtree;
      dsLookForDomain.PropertiesToLoad.Add("fsmoRoleOwner");
      dsLookForDomain.PropertiesToLoad.Add("distinguishedName");
    
      srcDomains = dsLookForDomain.FindAll();
      foreach (SearchResult sr in srcDomains)
      {
        /* For each root look for the groups containing my user
         */
        string fsmoRoleOwner = sr.Properties["fsmoRoleOwner"][0].ToString();
        string distinguishedName = sr.Properties["distinguishedName"][0].ToString();
        Regex srvNameRegEx = new Regex("^CN=NTDS Settings,CN=(.*),CN=Servers,.*$");
        Match found = srvNameRegEx.Match(fsmoRoleOwner);
    
        if (distinguishedName.Contains("Schema"))
          Console.WriteLine("Schema Manager is {0}", found.Groups[1].Value);
      }
    
      /* Search the domain FSMO role
      */
      sFromWhere = ldapBase + configurationNamingContext;
      deBase = new DirectoryEntry(sFromWhere, "dom\\jpb", "pwd");
    
      dsLookForDomain = new DirectorySearcher(deBase);
      dsLookForDomain.Filter = "(fsmoRoleOwner=*)";
      dsLookForDomain.SearchScope = SearchScope.Subtree;
      dsLookForDomain.PropertiesToLoad.Add("fsmoRoleOwner");
      dsLookForDomain.PropertiesToLoad.Add("distinguishedName");
    
      srcDomains = dsLookForDomain.FindAll();
      foreach (SearchResult sr in srcDomains)
      {
        /* For each root look for the groups containing my user
         */
        string fsmoRoleOwner = sr.Properties["fsmoRoleOwner"][0].ToString();
        string distinguishedName = sr.Properties["distinguishedName"][0].ToString();
        Regex srvNameRegEx = new Regex("^CN=NTDS Settings,CN=(.*),CN=Servers,.*$");
        Match found = srvNameRegEx.Match(fsmoRoleOwner);
    
        if (distinguishedName.Contains("Partitions"))
          Console.WriteLine("Domain Manager is {0}", found.Groups[1].Value);
      }
    }
