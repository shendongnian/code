    using System;
    
    class Program
    {
        static void Main()
        {
    	string s = "1,2,3,4";
    	//
    	// Split string on comma.
    	// ... This will separate all the words.
    	//
    	string[] words = s.Split(',');
    	foreach (string word in words)
    	{
    	    Console.WriteLine(word);
    	}
        }
    }
