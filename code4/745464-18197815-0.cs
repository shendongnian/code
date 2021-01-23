    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "mine.domain.com");
    GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, "myADGroup");
    if (grp != null)
    {
        DumpMembership(grp,0);        
    }
    private void DumpMembership(GroupPrincipal node, int level)
    {     
      string grpPfx = new string("\t",level);
      string mbrPfx = new string("\t",level+1);
      PrincipalSearchResult<Principal> rslts = node.GetMembers();
      Console.WriteLine("{0}Group--{1}",grpPfx,node.Name);
      foreach(UserPrincipal usr in rslts.Where(u => u is UserPrincipal))
          Console.WriteLine("{0}User: {1}",mbrPfx,usr.Name;
      foreach(GroupPrincipal grp in rslts.Where(g => g is GroupPrincipal))
          DumpMembership(grp,level + 1);
    }
