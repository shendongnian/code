    // find the group in question (or load it from e.g. your list)
    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
  
    // if found....
    if (group != null)
    {
       // iterate over members
       foreach (Principal p in group.GetMembers())
       {
          Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
          // do whatever you need to do to those members
       }
    }
