    using System;
    using System.Text.RegularExpressions;
    
    class TestProgram
    {
        static string RemoveSpaces(string value)
        {
    	return Regex.Replace(value, @"\s+", " ");
        }
    
        static void Main()
        {
    	string value = "Sunil  Tanaji  Chavan";
    	Console.WriteLine(RemoveSpaces(value));
    	value = "Sunil  Tanaji\r\nChavan";
    	Console.WriteLine(RemoveSpaces(value));
        }
    }
