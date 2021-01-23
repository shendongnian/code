     PrincipalContext pr = new PrincipalContext(ContextType.Domain, "corp.local", "dc=corp,dc=local", username, password);
    GroupPrincipal group = GroupPrincipal.FindByIdentity(pr, groupName);//Looking for the Group in AD Server
            
    if (group == null)
      {
         //Throw Exception
      }
    
    UserPrincipal user = UserPrincipal.FindByIdentity(pr, userName);//Looking  for the User in AD Server
    
    if (user.IsMemberOf(group))//If Group is already added to the user
       {
           //I have Put it into If else condition because in case you want to Remove Groups from that User you can write your Logic here.
             
         //Do Nothing, Because the group is already added to the user
       }
     else// Group not found in the Current user,Add it
       {
          if (user != null & group != null)
           {
             group.Members.Add(user);
             group.Save();
             done = user.IsMemberOf(group);//You can confirm it from here
            }
       }
         pr.Dispose();
         return done;
