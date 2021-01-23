    //In your application layer
    public class RecordsViewModel
    {
        public ObservableCollection<Record> Records {get;set;}
    }
    
    
    //In your domain layer
    
    public class Record
    {
    	//Properties from Entity1
    	
    	//Properties from Entity2
    }
    //In your Data Access Layer
    
    public class Repository
    {
    	public IEnumerable<Record> GetRecords()
    	{
    		return db.Entity1.Include(Entity2)
    				.Select(e => 
    					new Record() 
    						{ 
    							//object initialization
    						});
    	}
    }
