    namespace JobTrack.Concrete
    {
        public class EFDbContext : DbContext 
        {
            //Set the entity framework database context to the connection name
            //in the Webconfig file for our SQL Server data source QSJTDB1
            public EFDbContext() : base("name=EFDbConnection")
            {            
            }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove the tight dependency on the entity framework that 
            //wants to take control of the database. EF by nature wants
            //to drive the database so that the database changes conform
            //to the model changes in the application. This will remove the
            //control from the EF and leave the changes to the database admin
            //side so that it continues to be in sync with the model.
            Database.SetInitializer<EFDbContext>(null);
            //Remove the default pluaralization of model names
            //This will allow us to work with database table names that are singular
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }
        //Allows for multiple entries of the class State to be used with 
        //interface objects such as IQueryTables for the State database table  
        public DbSet<State> State { get; set; } 
    }
}
