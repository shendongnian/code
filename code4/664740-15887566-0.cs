    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="Hello World";
    
          string re1="(Hello)";	// Word 1
          string re2=".*?";	// Non-greedy match on filler
          string re3="((?:[a-z][a-z]+))";	// Word 2
    
          Regex r = new Regex(re1+re2+re3,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String word1=m.Groups[1].ToString();
                String word2=m.Groups[2].ToString();
                Console.Write("("+word1.ToString()+")"+"("+word2.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
