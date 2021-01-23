    using System;
    using System.Text.RegularExpressions;
    
    public static class Program
    {
    	public static void Main(string[] args)
    	{
    		string before = @"P C $10000 F + T X (A) ";
    		string after = Regex.Replace(before, @"(?<a> -?\$?\s*-?\s*[\d.]+ )|(?<b>\s*.*?(\s?))", 
    					m => m.Groups["a"].Success? m.Value : m.Value.Trim());
    		
    		Console.WriteLine("before: '{0}', after: '{1}'", before, after);
    	}
    }
