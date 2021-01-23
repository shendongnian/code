    public class MyContext : DbContext
    {
    	static private Initializer DbInitializer;
    	static MyContext()
    	{
    		DbInitializer = new MyContext.Initializer();
    		Database.SetInitializer<MyContext>(DbInitializer);
    	}
    }
    public class Initializer : IDatabaseInitializer<MyContext>
    {
    	public void InitializeDatabase(MyContext context)
    	{
    		string ddl = "(Some SQL command to e.g. create an index or create a user)";
    		context.Database.ExecuteSqlCommand(ddl);
    	}
    }
