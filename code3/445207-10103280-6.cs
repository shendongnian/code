    public class SiteSetting
    {
    	public Site Site {
    		get; set; //Site would just be a simple class consisiting of Id, Key and Name to match the database table
    	}
    	
    	protected Dictionary<String, String> Settings { get; set; } //Simple key value pairs
    	
    }
