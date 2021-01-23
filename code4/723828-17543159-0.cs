        public class Context : DbContext
        {
            public DbSet<MessageType> MessageTypes { get; set; }
            public DbSet<Message> Messages { get; set; }
            public DbSet<Delivery> Deliveries { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Server> Servers { get; set; }
            public DbSet<Registration> Registrations { get; set; }
    
            public class Initializer : IDatabaseInitializer<Context>
            {
                public void InitializeDatabase(Context context)
                {
                    if (context.Database.Exists() && !context.Database.CompatibleWithModel(false))
                        context.Database.Delete();
    
                    if (!context.Database.Exists())
                    {
                        context.Database.Create();
                        context.Database.ExecuteSqlCommand(
                           @"alter table Servers 
                             add constraint UniqueServerName unique (Name)");
                    }
                }
            }
        }
