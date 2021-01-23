    public List<UserPrincipal> FindAllUsers(List<Guid> allGuids)
    {
       List<UserPrincipal> result = new List<UserPrincipal>();
       
       // set up domain context
       using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
       {
           foreach(Guid userGuid in allGuids)
           { 
              // find a user
              UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userGuid);
    
              if(user != null)
              {
                  result.Add(user);
              }
           }
        }
       
        return result;
    }
