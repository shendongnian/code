    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
    	// Example Dictionary again
    	Dictionary<string, int> d = new Dictionary<string, int>()
    	{
    	    {"cat", 2},
    	    {"dog", 1},
    	    {"llama", 0},
    	    {"iguana", -1}
    	};
    	// Loop over pairs with foreach
    	foreach (KeyValuePair<string, int> pair in d)
    	{
    	    Console.WriteLine("{0}, {1}",
    		pair.Key,
    		pair.Value);
    	}
    	// Use var keyword to enumerate dictionary
    	foreach (var pair in d)
    	{
    	    Console.WriteLine("{0}, {1}",
    		pair.Key,
    		pair.Value);
    	}
        }
    }
