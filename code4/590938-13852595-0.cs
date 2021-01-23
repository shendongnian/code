    using System;
    using System.Text.RegularExpressions;
    class Program
        {
            static void Main()
            {
	         long a = CountLinesInString("This is an\r\nawesome website.");
	         Console.WriteLine(a);
	         long b = CountLinesInStringSlow("This is an awesome\r\nwebsite.\r\nYeah.");
	         Console.WriteLine(b);
             }
             static long CountLinesInString(string s)
             {
	          long count = 1;
	          int start = 0;
	          while ((start = s.IndexOf('\n', start)) != -1)
	          {
	              count++;
	               start++;
	          } 
	          return count;
             }
             static long CountLinesInStringSlow(string s)
             {
	          Regex r = new Regex("\n", RegexOptions.Multiline);
	          MatchCollection mc = r.Matches(s);
	          return mc.Count + 1;
             }
     }
