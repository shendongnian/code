    using System;
    
    class Program
    {
        static void Main()
        {
    	    const string s = "Hello!";
            // Option 1
    	    foreach (char c in s)
    	    {
    	        Console.WriteLine(c);           // Your treatment here
    	    }
            // Option 2
    	    for (int i = 0; i < s.Length; i++)
    	    {
    	        Console.WriteLine(s[i]);        // Your treatment here
    	    }
        }
    }
