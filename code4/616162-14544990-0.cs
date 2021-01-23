    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static int Compare1(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
    	return a.Key.CompareTo(b.Key);
        }
    
        static int Compare2(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
    	return a.Value.CompareTo(b.Value);
        }
    
        static void Main()
        {
    	var list = new List<KeyValuePair<string, int>>();
    	list.Add(new KeyValuePair<string, int>("Perl", 7));
    	list.Add(new KeyValuePair<string, int>("Net", 9));
    	list.Add(new KeyValuePair<string, int>("Dot", 8));
    
    	// Use Compare1 as comparison delegate.
    	list.Sort(Compare1);
    
    	foreach (var pair in list)
    	{
    	    Console.WriteLine(pair);
    	}
    	Console.WriteLine();
    
    	// Use Compare2 as comparison delegate.
    	list.Sort(Compare2);
    
    	foreach (var pair in list)
    	{
    	    Console.WriteLine(pair);
    	}
        }
    }
