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
    		return db.Entity1.Include("Entity2")
    				.Select(e => 
    					new Record() 
    						{ 
    							//object initialization
    						});
    	}
    	
    	public void Update(IEnumerable<Record> records)
    	{
    		var recordIds = records.Select(r => r.Id);
    		
    		var entities = db.Entity1.Include("Entity2").Where(e => recordIds.Contains(e.Id));
    		
    		foreach(var record in records)
    		{
    			var entity = entities.SingleOrDefault(e => e.Id == record.Id);
    			
    			if (entity == null)
    			{
    				entity = new Entity1();
    				db.Entity1.Add(entity);
    			}
    			
    			//update properties on Entity1
    			
    			//check if Entity2 should exist
    			//If so, create/update entity2
    			//If not, decide if you should delete entity2 or simply set Entity1.Entity2 to null
    		}
    	}
    }
