    public class MyClass
    {
    	public Boolean success { get; set; }
    	public String msg { get; set; }
        
        // class to string
    	public override string ToString()
    	{
    		return success.ToString() + "," + msg;
    	}
    
    	public MyClass(){}
    
        // string to class
    	public MyClass(string myclassTostring)
    	{
    		string[] props = myclassTostring.Split(',');
    		success = Convert.ToBoolean(props[0]);
    		msg = props[1];
    	}
    
    }
