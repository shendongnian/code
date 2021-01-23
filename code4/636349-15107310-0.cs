    public void Method<T>(T val)
    {
        string valString = val as string;
    	if(valString != null)
    	{
    		Console.WriteLine (valString.Length);
    	}
    }
    Method("tyto"); //prints 4
    Method(5); //prints nothing
