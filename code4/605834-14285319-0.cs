    var adminGroupMembers = (IEnumerable)groupEntry.Invoke("Members");
    ....
    //where userGroups contains all AD group names to which user belongs to
    foreach(var group in userGroups)
    { 
       if(adminGroupMembers.Contains(group))
       {
          IsUserAdmin = true;
          break;
       }
    }
        
