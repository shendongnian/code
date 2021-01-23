    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="L - V 8:30 a 22:00 hrs. Sab y Dom..11:00 a 22:00 hrs.";
    
          string re1="(L)";	// Any Single Character 1
          string re2=".*?";	// Non-greedy match on filler
          string re3="(-)";	// Any Single Character 2
          string re4=".*?";	// Non-greedy match on filler
          string re5="(V)";	// Any Single Character 3
          string re6=".*?";	// Non-greedy match on filler
          string re7="(Dom)";	// Word 1
    
          Regex r = new Regex(re1+re2+re3+re4+re5+re6+re7,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String c1=m.Groups[1].ToString();
                String c2=m.Groups[2].ToString();
                String c3=m.Groups[3].ToString();
                String word1=m.Groups[4].ToString();
                Console.Write("("+c1.ToString()+")"+"("+c2.ToString()+")"+"("+c3.ToString()+")"+"("+word1.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
