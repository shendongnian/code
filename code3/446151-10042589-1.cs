    interface IWrite
    {
    	string Data { get; set; }
    	void Write();
    }
    
    interface IRead
    {
    	string Data { get; set; }
    	void Read();
    }
    
    public class Lease
    {
    	//..
    }
    
    public class PrivateLease : Lease, IWrite, IRead
    {
    	// other implementations
    	public string Data { get; set; }
    	public void Read()
    	{
    		//..
    	}
    	public void Write()
    	{
    		//..
    	}
    }
    public class BusinessLease : Lease, IRead
    {
    	// other implementations
    	public string Data { get; set; }
    	public void Read()
    	{
    		//..
    	}
    }
