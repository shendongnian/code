    public class ObjectContextManager
    {
    	public ObjectSet GetSet<T>()  
    	{
    		var connStr = ConfigurationManager.ConnectionStrings["Entities"];
    		ObjectContext context = new ObjectContext(connStr.ConnectionString);
    		return context.CreateObjectSet<T>();
    	}
    }
