    private static void Main(string[] args)
    {            
    	var list = new Dictionary<string, DateTime>();
    	list.Add("John", DateTime.Now.AddSeconds(-1));
    	list.Add("Mark", DateTime.Now.AddSeconds(-5));
    	list.Add("Andy", DateTime.Now.AddSeconds(-5));
    
    	PrintList(ref list);
    
    	IsSpam(ref list, "John");
    	PrintList(ref list);
    	IsSpam(ref list, "Andy");
    	PrintList(ref list);
    	IsSpam(ref list, "Andy");
    	PrintList(ref list);
    }
    
    private static void IsSpam(ref Dictionary<string, DateTime> list, string username)
    {
    	if (list.ContainsKey(username))
    	{
    		if (list[username] < DateTime.Now.AddSeconds(-3))
    			Console.WriteLine("Not a spam");
    		else
    			Console.WriteLine("Spam");
    
    		list[username] = DateTime.Now;
    	}
    	else
    	{
    		list.Add(username, DateTime.Now);
    	}
    }
    
    private static void PrintList(ref Dictionary<string, DateTime> list)
    {
    	foreach (var c in list)
    		Console.WriteLine("user: {0}, time: {1}", c.Key, c.Value);
    }		
