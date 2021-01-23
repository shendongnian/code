    public class MasterDetailContext : DbContext
    {
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Master> Master { get; set; }
        // this one is used by DbMigrator - I am NOT going to use it in my code
        public MasterDetailContext()
        {
            Database.Initialize( true );
        }
        // rather - I am going to use this, I want dynamic connection strings
        public MasterDetailContext( string ConnectionString ) : base( ConnectionString )
        {
            Database.SetInitializer( new CustomInitializer() );
            Database.Initialize( true );
        }
        protected override void  OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    public class CustomInitializer : IDatabaseInitializer<MasterDetailContext>
    {
        #region IDatabaseInitializer<MasterDetailContext> Members
        // fix the problem with MigrateDatabaseToLatestVersion 
        // by copying the connection string FROM the context
        public void InitializeDatabase( MasterDetailContext context )
        {            
            Configuration cfg = new Configuration(); // migration configuration class
            cfg.TargetDatabase = new DbConnectionInfo( context.Database.Connection.ConnectionString, "System.Data.SqlClient" );
            DbMigrator dbMigrator = new DbMigrator( cfg );
            // this will call the parameterless constructor of the datacontext
            // but the connection string from above will be then set on in
            dbMigrator.Update();             
        }
        #endregion
    }
