    class Program
    {
        static void Main()
        {
    	var d = new Dictionary<string, int>();
    	d.Add("key", 0);
    	// This code does two hash lookups.
    	int value;
    	if (d.TryGetValue("key", out value))
    	{
    	    d["key"] = value + 1;
    	}
        }
    }
