    public class MyDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Account>( ).ToTable( "dbo.Accounts" );
            //and perhaps the columns as well
            modelBuilder.Entity<Account>( ).Property( p => p.Id )
                                           .HasColumnName( "Id" );
    }
