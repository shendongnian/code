    using System;
    
    class Program
    {
        static void Main()
        {
    	string input = "OneTwoThree";
    
    	// Get first three characters
    	string sub = input.Substring(0, 3);
    	Console.WriteLine("Substring: {0}", sub);
        }
    }
