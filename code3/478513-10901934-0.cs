    using System;
    class Program
    {
        static void Main()
        {
    	    string s = "there, is, a, cat";
    	    string[] words = s.Split(', ');
	    foreach (string word in words)
	    {
	        Console.WriteLine(word);
	    }
        }
    }
