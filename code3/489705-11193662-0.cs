    public void Method()
    {
    	Func<string, bool> isSet = (x => x.Length > 0);
    	
    	List<string> testlist = new List<string>() {"", "fasfas", "","asdalsdkjasdl", "asdasd"};
    	foreach (string val in testlist)
    	{
    		string text = String.Format("Value is {0}, Is Longer than 0 length: {1}", val, isSet(val));
    		Console.WriteLine(text);
    	}
    }
