    using(context = new MyEntity())
    {
        // fetch Groups and add them first
        foreach(groupId in csvSource.Select(x => x.GroupID).Distinct())
        {
             context.Groups.Add(new Group { ID = groupId });
        }
        // add users
        foreach(csvUser from csvSource)
        {
            User oUser = new User();
            oUser.Firstname = csvUser.Firstname;
            var existingGroup = context.Groups.Single(x => x.Id == csvUser.GroupID);
            oUser.Groups.Add(existingGroup);
            context.Users.Add(oUser);
        }   
        context.saveChnages();
    }
