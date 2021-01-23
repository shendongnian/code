    Program that reads all lines: C#
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	//
    	// Read in a file line-by-line, and store it all in a List.
    	//
    	List<string> list = new List<string>();
    	using (StreamReader reader = new StreamReader("file.txt"))
    	{
    	    string line;
    	    while ((line = reader.ReadLine()) != null)
    	    {
    		list.Add(line); // Add to list.
    		Console.WriteLine(line); // Write to console.
    	    }
    	}
        }
    }
    
    Output
    
    First line of your file.txt file.
    Second line.
    Third line.
    Last line.
