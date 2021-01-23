	ShowResults s = "hello";
	string ss = s;
	Console.WriteLine(ss); // "hello"
    class ShowResults
    {
    	public string SomeProp
    	{
    		get; private set;
    	}
    	public static implicit operator ShowResults(string s)
    	{
    		//this is where you'd parse your string
    		//to form a valid ShowResults
    		return new ShowResults{SomeProp = s};
    	}
    	public static implicit operator string(ShowResults s)
    	{
    		return s.SomeProp;
    	}
    }
