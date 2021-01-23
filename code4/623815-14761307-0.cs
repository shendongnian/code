    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		Console.WriteLine(Regex.IsMatch("\"asdf\"", "^\"[\\p{L}]{3,32}\"$"));  //True
    	}
    }
