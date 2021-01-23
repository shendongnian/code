    using System;
    using System.Text.RegularExpressions;
 
    public class Example
    {
       public static void Main()
       {
           string pattern =  @"\<A(G|H|I)\>\!([^\!]*)\!";
           string input = "<AI>!n!-Butyl acetate the quick brown "
               + "<AI>!fox jumps! over the lazy dog!";
           string replacement = "$2";
           Regex rgx = new Regex(pattern);
           string result = rgx.Replace(input, replacement);
 
           Console.WriteLine("Original String:    '{0}'", input);
           Console.WriteLine("Replacement String: '{0}'", result);                             
        }
    }
    Original String:    '<AI>!n!-Butyl acetate the quick brown <AI>!fox jumps! over the lazy dog!'
    Replacement String: 'n-Butyl acetate the quick brown fox jumps over the lazy dog!'
