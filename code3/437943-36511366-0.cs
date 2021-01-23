    using System;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	// Call EnumerateFiles in a foreach-loop.
    	foreach (string file in Directory.EnumerateFiles(@"c:\files",
    	    "*.xml",
    	    SearchOption.AllDirectories))
    	{
    	    // Display file path.
    	    Console.WriteLine(file);
    	}
        }
    }
