    [XmlRoot("api_data")]
    public class ApiData
    {
    	[XmlElement("status")]
    	public string Status { get; set; }
    	
    	[XmlElement("sessions")]
    	public List<Session> Sessions { get; set; }
    }
    
    public class Session
    {
    	[XmlElement("id")]
    	public int ID { get; set; }
    	
    	[XmlElement("sessionID")]
    	public string SessionID { get; set; }
    	
    	[XmlElement("gameID")]
    	public int GameID { get; set; }
    	
    	[XmlElement("maxPlayers")]
    	public int MaxPlayers { get; set; }
    	
    	[XmlElement("hostIP")]
    	public string HostIP { get; set; }
    	
    	[XmlElement("hostPort")]
    	public int HostPort { get; set; }
    	
    	[XmlElement("inProgress")]
    	public int InProgress { get; set; }
    	
    	[XmlElement("timestamp")]
    	public int TimeStamp { get; set; }
    }
