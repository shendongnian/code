    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="ABC500";
    
          string re1="((?:[a-z][a-z]+))";	
          string re2="(\\d+)"
    
          Regex r = new Regex(re1+re2,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String word1=m.Groups[1].ToString();
                String int1=m.Groups[2].ToString();
                Console.Write("("+word1.ToString()+")"+"("+int1.ToString()+")"+"\n");
          }
        }
      }
    }
