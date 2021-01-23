    using (InventorySystemEntities context = new InventorySystemEntities(new ConfigurationManager().ConnectionString))
    {
        var newUser = new context.Users.CreateNew();
        newUser.UserGroup = context.UserGroup.Find(1);
        context.Users.Add(newUser);
        context.SaveChanges();
    }
