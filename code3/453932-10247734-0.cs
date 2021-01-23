    [DataContract]
    public class Customer
    {
    	[DataMember]
    	public string Name { get; set; }
    }
    
    [ServiceContract]
    public interface IService
    {
    	Customer GetCustomer(int customerId);
    }
    
    [ServiceBehavior]
    public class Service
    {
    	[OperationContract]
    	public Customer GetCustomer(int customerId)
    	{
    		// Insert DB-related implementation of your query:
    		// - you could hard-code a SQL query
    		// - you could use Entity-Framework or other ORM
    		//
    		// First, create your connection to your database
    		// Then query
    		// Then close your connection
    		//
    		// Example with SQL connection
    		// Connection string comes from server configuration (app.config or whatever)
    		using (SqlConnection cn = new SqlConnection(connectionString))
    		{
    			Customer res = new Customer();
    			
    			// query here
    			
    			Customer.Name = XXX;	// From DB result
    		}
    	}
    }
