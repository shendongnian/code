    using System;
    
    class Program
    {
        static void Main()
        {
    	// A.
    	// The input string.
    	const string s = "Tom Cruise is an Idiot he should pay $54.95.";
    
    	// B.
    	// Test with IndexOf.
    	if (s.IndexOf("$") != -1)
    	{
    	    Console.Write("string contains '$'");
    	}
    	Console.ReadLine();
        }
    }
