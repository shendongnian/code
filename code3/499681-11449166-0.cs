    public class ObjectContextManager
    {
      public ObjectContext GetContext<T>()  
      {
    	var connStr = ConfigurationManager.ConnectionStrings["Entities"];
    	ObjectContext context = new ObjectContext(connStr.ConnectionString);
    	return context.CreateObjectSet<T>();
      }
    }
