    public static void LoadUserGroup(User user)
    {
        using (InventorySystemEntities context = new InventorySystemEntities(
            new ConfigurationManager().ConnectionString))
        {
            context.Users.Attach(user);
            context.Entry(user).Reference(u => u.UserGroup).Load();
        }
    }
