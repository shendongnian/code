    namespace Vidly.Migrations
    {
        using System;
        using System.Data.Entity;
        using System.Data.Entity.Migrations;
        using System.Linq;
    
        internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.MyDbContext>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
            }
    
            protected override void Seed(Vidly.Models.MyDbContext context)
            {
                //  This method will be called after migrating to the latest version.
    
                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.
            }
        }
    }
