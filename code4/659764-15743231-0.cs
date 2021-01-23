    using System;
    
    class Program
    {
        static void Main()
        {
    	//
    	// Write prime numbers between 0 and 100.
    	//
    	Console.WriteLine("--- Primes between 0 and 100 ---");
    	for (int i = 0; i < 100; i++)
    	{
    	    bool prime = PrimeTool.IsPrime(i);
    	    if (prime)
    	    {
    		Console.Write("Prime: ");
    		Console.WriteLine(i);
    	    }
    	}
    	//
    	// Write prime numbers between 10000 and 10100
    	//
    	Console.WriteLine("--- Primes between 10000 and 10100 ---");
    	for (int i = 10000; i < 10100; i++)
    	{
    	    if (PrimeTool.IsPrime(i))
    	    {
    		Console.Write("Prime: ");
    		Console.WriteLine(i);
    	    }
    	}
        }
    }
