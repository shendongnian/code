    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="aa4"; //for instance.
    
          string re1="([a-zA-Z])";	
          string re2="([a-zA-Z])";	
          string re3="(\\d+)";	
    
          Regex r = new Regex(re1+re2+re3,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String w1=m.Groups[1].ToString();
                String w2=m.Groups[2].ToString();
                String d1=m.Groups[3].ToString();
                Console.Write("("+w1.ToString()+")"+"("+w2.ToString()+")"+"("+d1.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
