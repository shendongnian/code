    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find a two users
    UserPrincipal user1 = UserPrincipal.FindByIdentity(ctx, IdentityType.Guid, user1Guid);
    UserPrincipal user2 = UserPrincipal.FindByIdentity(ctx, IdentityType.Guid, user2Guid);
    
    if(user1 != null && user2 != null)
    {
         DirectoryEntry dirEntry1 = user1.GetUnderlyingObject() as DirectoryEntry;
         DirectoryEntry dirEntry2 = user2.GetUnderlyingObject() as DirectoryEntry;
         // if both are OK, get the parents and compare their GUID
         if(dirEntry1 != null && dirEntry2 != null)
         {
             DirectoryEntry parent1 = dirEntry1.Parent;
             DirectoryEntry parent2 = dirEntry2.Parent;
             bool areInSameOU = (parent1.Guid == parent2.Guid);
         }
    }
