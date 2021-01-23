    public SimpleMembershipInitializer()
    {
    #if DEBUG
        Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
    #else
        Database.SetInitializer<DataContext>(null);
    #endif
    
        try
        {
            using (var context = new DataContext())
            {
                if (!context.Database.Exists())
                {
                    ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                }
                context.Database.Initialize(true);
            }
    
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "EmailAddress", autoCreateTables: true);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
        }
    }
