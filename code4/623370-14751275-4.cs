	public class TestClass
    {
    	private int mIntMemeber = 0;					// # to test int type	
    	private string mStringMember = "abc";			// # to test string type (initialized)
    	private string mNullStringMember = null;		// # to test string type (null)
			
	    private static string mStaticNullStringMember;  // # to test string type (static)
		// # Defining properties for each member
    	public int IntMember							
    	{
    		get { return mIntMemeber; }
    		set { mIntMemeber = value; }				
    	}
    
    	public string StringMember						
    	{
    		get { return mStringMember; }
    		set { mStringMember = value; }
    	}
    	public string NullStringMember
    	{
    		get { return mNullStringMember; }
    		set { mNullStringMember = value; }
		}
		public static string StaticNullStringMember
		{
			get { return mStaticNullStringMember; }
			set { mStaticNullStringMember = value; }
		}
    }
