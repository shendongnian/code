    using System;
    using System.Collections;
    
    class Program
    {
        static void Main()
        {
    	string[] highways = new string[]
    	{
    	    "100F",
    	    "50F",
    	    "SR100",
    	    "SR9"
    	};
    	//
    	// We want to sort a string array called highways in an
    	// alphanumeric way. Call the static Array.Sort method.
    	//
    	Array.Sort(highways, new AlphanumComparatorFast());
    	//
    	// Display the results
    	//
    	foreach (string h in highways)
    	{
    	    Console.WriteLine(h);
    	}
        }
    }
