    using System;
    
    class Program
    {
        static void Main()
        {
    	     string s = "1,2,3,4";
    	     string[] numbers = s.Split(',');
    	     foreach (string num in numbers)
    	     {
    	         Console.WriteLine(num);
    	     }
        }
    }
