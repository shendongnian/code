    public class LXRecord
    {
    	public string ItemNumber { get; set; }
    	public string LastName { get; set; }
    	public string Date { get; set; }
    	public List<string> Errors { get; set; }
    	
    	public LXRecord()
    	{
    		Errors = new List<String>();
    	}
    }
