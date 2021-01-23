        public class MyProjectContext : DbContext
        {
            ...
            public DbSet<SomeModel> SomeModels { get; set; }
            public DbSet<SomeOtherModel> SomeOtherModels { get; set; }
            # etc.
        }
