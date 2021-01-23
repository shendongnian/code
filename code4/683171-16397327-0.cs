    using System;
    
    class Program
    {
        static void Main()
        {
    	//
    	// Declare a nullable DateTime instance and assign to null.
    	// ... Change the DateTime and use the Test method (below).
    	//
    	DateTime? value = null;
    	Test(value);
    	value = DateTime.Now;
    	Test(value);
    	value = DateTime.Now.AddDays(1);
    	Test(value);
    	//
    	// You can use the GetValueOrDefault method on nulls.
    	//
    	value = null;
    	Console.WriteLine(value.GetValueOrDefault());
        }
    
        static void Test(DateTime? value)
        {
    	//
    	// This method uses the HasValue property.
    	// ... If there is no value, the number zero is written.
    	//
    	if (value.HasValue)
    	{
    	    Console.WriteLine(value.Value);
    	}
    	else
    	{
    	    Console.WriteLine(0);
    	}
        }
    }
