     public static bool IsAuthorizedUser(string userId) 
     {
         PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
         UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, userId);
         bool result = false;
         if(usr == null)
         {
             Console.WriteLine("usr is null");
         }
         else
         {
             foreach (Principal p in usr.GetAuthorizationGroups())
             {
                 if (p.ToString() == "Administrators")
                 {
                     result = true;
                 }
             }
          }
          return result;
        }
