        public class SimpleMembershipContext : DbContext
        {
            public SimpleMembershipContext()
                : base("name=YourConnectStringName")
            {
                // this tells EF to not worry about migrating or modifying the database
                Database.SetInitializer<SimpleMembershipContext>(null);
            }
            public DbSet<Membership> Memberships { get; set; }
        }
    Replace the "YourConnectionStringName" with the name of the connection string for your project's database (in web.config). This could also be a totally different database if you're storing the membership stuff somewhere else, as well.
