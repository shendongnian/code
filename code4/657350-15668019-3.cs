    public class MyService
    {
        protected DataContext DataContext { get; set; }
        public MyService(DataContext dataContext)
        {
            DataContext = dataContext;
            DataContext.Database.Connection.ConnectionString = "conn string";
        }
    }
