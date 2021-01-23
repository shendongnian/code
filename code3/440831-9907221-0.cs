    using System.DirectoryServices.AccountManagement;
    using System.DirectoryServices;
    // Authentication
    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, sDn))
    {
       // validate the credentials
       bIsValid = pc.ValidateCredentials(sUsr, sPassword);
    }
    //List users
    DirectorySearcher adsSearcher = new DirectorySearcher();
    adsSearcher.Filter = string.Format(Parameters.ActiveDirectoryFilter, "*");
    try
    {
       foreach (SearchResult sr in adsSearcher.FindAll())
       {
           string sUsrName = sr.GetDirectoryEntry().Properties["UserPrincipalName"].Value as string;
           Console.WriteLine(string.Format("User : {0}", sUsrName));
       }
    }
