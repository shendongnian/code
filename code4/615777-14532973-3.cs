    public class api_data
    {
    	public string status { get; set; }
    	
    	[XmlElement]
    	public session[] sessions { get; set; }
    }
    
    public class session
    {
    	public int id { get; set; }
    	public string sessionID { get; set; }
    	public int gameID { get; set; }
    	public int maxPlayers { get; set; }
    	public string hostIP { get; set; }
    	public int hostPort { get; set; }
    	public int inProgress { get; set; }
    	public int timestamp { get; set; }
    }
