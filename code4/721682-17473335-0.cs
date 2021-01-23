    User newUser = new User();
    newUser.UserGroupID = 1;
    newUser.UserGroup = UserGroup.Find(1);
    using (InventorySystemEntities context = new InventorySystemEntities(new ConfigurationManager().ConnectionString))
    {
        context.UserGroups.Attach(newUser.UserGroup);
        context.Users.Add(newUser);
        context.SaveChanges();
    }
    
