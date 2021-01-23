    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
    	if (args == null)
    	{
    	    Console.WriteLine("args is null"); // Check for null array
    	}
    	else
    	{
    	    Console.Write("args length is ");
    	    Console.WriteLine(args.Length); // Write array length
    	    for (int i = 0; i < args.Length; i++) // Loop through array
    	    {
    		string argument = args[i];
    		Console.Write("args index ");
    		Console.Write(i); // Write index
    		Console.Write(" is [");
    		Console.Write(argument); // Write string
    		Console.WriteLine("]");
    	    }
    	}
    	Console.ReadLine();
        }
    }
