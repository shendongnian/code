    public class GroupData {
        [JsonIgnore]
    	public string groupParam { get; set; }
        [JsonIgnore]
    	public GroupData nestedObject { get; set; }
    	public string[] arrayData { get; set; }
    }
