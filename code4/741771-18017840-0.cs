    // Now initialize it
    using (var context = new EMUI.Models.UsersContext())
    {
        if (!context.Database.Exists())
        {
                Configuration configuration = new Configuration();
                configuration.ContextType = typeof(EMUI.Models.UsersContext);
                var migrator = new DbMigrator(configuration);
                migrator.Update();
        }
    }
