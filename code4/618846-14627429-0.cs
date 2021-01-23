       using System;
       using System.Text.RegularExpressions;
        
        public class MyClass
        {
        	
        
        	static string [] strs = 
        	{		
                   "Some random Name 2 - Ep.1",
                   "Some random Name - Ep.1",
                   "Boff another 2 name! - Ep. 228",
                   "Another one & the rest - T1 Ep. 2",
                   "T5 - Ep. 2 Another Name",
                   "T3 - Ep. 3 - One More with an Hyfen",
                   @"Another one this time with a Date - 02/12/2012",
                   "10 Aug 2012 - Some Other 2 - Ep. 2",
                   "Ep. 93 -  Some program name",
                   "Someother random name - Epis. 1 e 2",
                   "The Last one with something inside parenthesis (V.O.)"};
        	
        	static string [] regexes = 
        	{
        		@"T\d+",
        		@"\-",
        		@"Ep(i(s(o(d(e)?)?)?)?)?\s*\.?\s*\d+(\s*e\s*\d+)*",
        		@"\d{2}\/\d{2}\/\d{2,4}",
        		@"\d{2}\s*[A-Z]{3}\s*\d{4}",
        		@"T\d+",
        		@"\-",
        		@"\!",
        		@"\(.+\)",
        	};
        	
        	public static void Main()
        	{
        		foreach(var str in strs)
        		{
        			string cleaned = str.Trim();
        			foreach(var cleaner in regexes)
        			{
        				cleaned = Regex.Replace(cleaned, "^" + cleaner, string.Empty, RegexOptions.IgnoreCase).Trim();	
        				cleaned = Regex.Replace(cleaned, cleaner + "$", string.Empty, RegexOptions.IgnoreCase).Trim();
        			}
        			Console.WriteLine(cleaned);
        		}
        		Console.ReadKey();
        	}
