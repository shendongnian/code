    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	// This is the input string we are replacing parts from.
    	string input = "http://cdn.example.com/content/dev/images/some.png";
    
    	// Use Regex.Replace to replace the pattern in the input.
    	  string output = Regex.Replace(input, "(?<=content\/).+(?=\/images)", "qa");
    
    	// Write the output.
    	Console.WriteLine(input);
    	Console.WriteLine(output);
        }
    }
