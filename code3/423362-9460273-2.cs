    /* Retreiving a principal context
     */
    PrincipalContext context = new PrincipalContext(ContextType.Domain, "WM2008R2ENT:389", "dc=dom,dc=fr", "jpb", "root.123");
    
    DirectoryContext dc = new DirectoryContext(DirectoryContextType.DirectoryServer, "WM2008R2ENT:389");
    Domain dn = Domain.GetDomain(dc);
    //Console.WriteLine("Le nom : {0}", dn.PdcRoleOwner.Domain);
    
    /* Retreive a users from group
     */
    using (var group = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, @"MonGrpSec"))
    { 
      if (group != null)
      {
        foreach (var p in group.GetMembers(false))
        {
          Console.WriteLine(p.SamAccountName);
        } 
      } 
    } 
