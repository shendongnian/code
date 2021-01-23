    private static void Main(string[] args)
    {
    	string[] a = new string[] { "a", "b", "c", "d" };
    	string[] b = new string[] { "c", "d" };
    
    	foreach (string tmp in a)
    	{
    		bool existsInB = false;
    		foreach (string tmp2 in b)
    		{
    			if (tmp == tmp2)
    			{
    				existsInB = true;
    				break;
    			}
    		}
    
    		if (!existsInB)
    		{
    			Console.WriteLine(string.Format("{0} is not in b", tmp));
    		}
    	}
    
    	Console.ReadLine();
    }
