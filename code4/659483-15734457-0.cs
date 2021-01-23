    public ConcurrentBag<Player> Players { get; set; }
    
    void Main()
    {
    	Players = new ConcurrentBag<Player>{ new Player {Id = "666"} };
    	
    	LookupPlayerById("666").Id = "my another freaking id";
    	
    	
    	Player searchResult; 
    	if (Players.TryTake(out searchResult)) //this will be the same object as above
    	{
    		Console.WriteLine (searchResut.Id); //prints my another freaking id
    	}
    }
    
    public Player LookupPlayerById(string clientId)
    {
        var player = Players.FirstOrDefault(x => x.Id == clientId);
        return player;
    }
    
    public class Player
    {
    	public string Id { get; set; }
    }
