    private static List<GroupObj> _groups = new List<GroupObj>();
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "mine.domain.com");
    GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, "myADGroup");
    if (grp != null)
    {        
      BuildHList(grp,0,null);
      foreach(UserPrincipal usr in grp.GetMembers(true))
         GetMbrPath(usr);        
    }
    private void BuildHList(GroupPrincipal node, int level, GroupPrincipal parent)
    {      
      PrincipalSearchResult<Principal> rslts = node.GetMembers();
      _groups.Add(new GroupObj() {Group=node, Level=level, Parent=parent};)
      foreach(GroupPrincipal grp in rslts.Where(g => g is GroupPrincipal))
          BuildHList(grp,level + 1,node);
    }
    private void FindMbrPath(UserPrincipal usr)
    {
     Stack<string> output = new Stack<string>();
     GroupObj fg = null;
     output.Push(usr.Name); 
     foreach(GroupObj go in _groups)
      {
       if(usr.IsMemberOf(go.Group))
        {
          output.Push(go.Group.Name);
          fg = go;
          while(fg.Parent != null)
          {
           output.Push(fg.Parent.Name);
           fg = fg.Parent;
          }
          break;
        }
      }
      while(output.Count > 1)
        Console.Write("{0} ->",output.Pop());
      Console.Write(output.Pop());
      Console.WriteLine();
    }
