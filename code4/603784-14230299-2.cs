    // custom datacontext class
     public class CustomDataContext : DataContext
     {  
        private static readonly string connectionString =
          @"Data Source=.\SQLExpress;Initial Catalog=<db name>;" +
          "Integrated Security=True"; // From the app.config
        public CustomDataContext() : base(connectionString) { }
        public Table<Cst_City> Cst_City
        {
          get { return this.GetTable<Cst_City>(); }
        }
      }
