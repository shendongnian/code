    using System;
    using System.Text.RegularExpressions;
    public class Test
    {
       public static void Main()
       {
           string input = "doin some replacement";
           string pattern = @"\bhello world'\b";
           string replace = "I love apple";
           string result = Regex.Replace(input, pattern, replace);        
        }
    }
