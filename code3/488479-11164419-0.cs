    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
    			var dbResults = GetMatches();
    			var firstLine = HtmlSubstring(dbResults[0], 0, 15);
    			Console.WriteLine(firstLine);
    			var secondLine = HtmlSubstring(dbResults[1], 0, 33);
    			Console.WriteLine(secondLine);
    			var thirdLine = HtmlSubstring(dbResults[2], 0, 10);
    			Console.WriteLine(thirdLine);
    
    			Console.Read();
            }
    
    		private static List<string> GetMatches()
    		{
    			return new List<string>
    			{
    				"i have been <em>match</em>ed"
    				,"a <em>match</em> will happen in the word <em>match</em>"
    				, "some random words including the word <em>match</em> here"
    			};
    		}
    
    		private static string HtmlSubstring(string mainString, int start, int length = int.MaxValue)
    		{
    			StringBuilder substringResult = new StringBuilder(mainString.Replace("</em>", "").Replace("<em>", "").Substring(start, length));
    
    			// Get indexes between start and (start + length) that need highlighting.
    			int matchIndex = mainString.IndexOf("<em>", start);
    			while (matchIndex > 0 && matchIndex < (substringResult.Length - start))
    			{
    				int matchIndexConverted = matchIndex - start;
    				int matchEndIndex = mainString.IndexOf("</em>", matchIndex) - start;
    
    				substringResult.Insert(matchIndexConverted, "<em>");
    				substringResult.Insert(Math.Min(substringResult.Length, matchEndIndex), "</em>");
    
    				matchIndex = mainString.IndexOf("<em>", matchIndex + 1);
    			}
    
    			return substringResult.ToString();
    		}
    	}
    }
