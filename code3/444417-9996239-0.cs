    string JASON = @"
    	{""Profile"": [{
    					""Name"":""Joe"",
    					""Last"":""Doe"",
    					""Client"":
    							{
    							""ClientId"":""1"",
    							""Product"":""Apple"",
    							""Message"":""Peter likes apples""
    							},
    					""Date"":""2012-02-14""
    					}]}
    ";
    void Main()
    {
    	var jason = JsonConvert.SerializeObject(Container.Instance());
    	JASON.Dump();
    	jason.Dump();
    	JsonConvert.DeserializeObject<Container>(JASON).Dump();
    }
    
    // Define other methods and classes here
    class Container
    {
    	public Container()
    	{
    		Profile = new List<Profile> { };
    	}
    	public List<Profile> Profile { get; set; }
    	
    	public static Container Instance()
    	{
    		var c = new Container();
    		c.Profile.Add(
    			new Profile {
    				Name = "Joe",
    				Last = "Doe",
    				Date = "2012-02-14",
    				Client = new Client{ ClientId = 1, Product = "Apple", Message = "Peter likes apples" }
    		});
    		return c;
    	}
    }
    
    class Client
    {
    	public int ClientId { get; set; }
    	public string Product { get; set; }
    	public string Message { get; set; }
    }
    
    class Profile
    {
    	public string Name {get; set;}
    	public string Last {get; set;}
    	public Client Client {get; set;}
    	public string Date {get; set;}
    	public Profile()
    	{ }
    }
