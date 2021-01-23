    public class KittenService : IDisposable
    {
    	public IEnumerable<Kitten> GetFluffyKittens()
    	{
    		using(var db = GetDbContextForFuffyKittens()){ // db can also be injected,
           		return db.Kittens // this explicit query is here
                          .Where(kitten=>kitten.fluffiness > 10) 
                          .Select(kitten=>new {
                                Name=kitten.name,
                                Url=kitten.imageUrl
                          }).Take(10); 
       		}
    	}
    	
    	protected KittenEntities GetDbContextForFuffyKittens(){
    		// ... code to determine the least used shard and get connection string ...
    		var connectionString = GetShardThatIsntBusy();
    		return new KittensEntities(connectionString);
    	}
    }
