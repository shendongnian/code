    public class JoinResults
    {
    	public int h { get; private set; }
    	public string gash { get; private set; }
    	public string groupId { get; private set; }
    	
    	public JoinResults(int h, string gash, string groupId)
    	{
    		this.h = h;
    		this.gash = gash;
    		this.groupId = groupId;
    	}
    }
