    void Main()
    {
    	try
    	{	
    		throw new Exception("Bar");
    	}
    	catch(Exception ex)
    	{
    		//I spit on the rules and change the message anyway
    		ex.GetType().GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ex, "Foo");
    		throw ex;
    	}
    }
