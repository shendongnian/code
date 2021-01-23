    void Main()
    {
    	var conn = new SqlConnection(@"Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI;");
    	var context = new MyContext(conn);
    }
    
    public class MyContext : DbContext
    {
    	public MyContext(DbConnection connection) : base(connection, true)
    	{
    	}
    }
