    foreach (var csvUser in csvSource)
    {
        User oUser = new User();
        oUser.Firstname = csvUser.Firstname;
        // Find Group
        var group = context.Groups.Find(csvUser.GroupID);
        
        if(group == null)
        {
           // TODO: Handle case that group is null
        }
        else
        {
            // Group found, assign it to the new user
            oUser.UserGroups.Add(new UserGroup { Group = group });
            context.Users.Add(oUser);
        }
    }
    context.SaveChanges();
