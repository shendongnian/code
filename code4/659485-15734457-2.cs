    ConcurrentBag<Player> Players;
    void Main()
    {
    	Players = new ConcurrentBag<Player> { 
                                         new Player 
                                         {
                                            Id = "1", 
                                            //note Value is false for IsReady
                          	                IsReady = new MonitoredValue<bool>(false)
                                         }};
    	
    	//this will change the underlying object of IsReady of Plater with id = 1
    	LookupPlayerById("1").IsReady.Value = true;
    	
    	Player searchResut;
    	if (Players.TryTake(out searchResut))
    	{
    		Console.WriteLine (searchResut.IsReady.Value); //prints true
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
    	public MonitoredValue<bool>  IsReady { get; set; }
    }
