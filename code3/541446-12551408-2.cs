    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="X. ZHAO1,";
    
          string re1="((?:[a-z][a-z0-9_]*))";	// Variable Name 1
          string re2="(\\.)";	// Any Single Character 1
          string re3="(\\s+)";	// White Space 1
          string re4="((?:[a-z][a-z0-9_]*))";	// Variable Name 2
          string re5="(,)";	// Any Single Character 2
    
          Regex r = new Regex(re1+re2+re3+re4+re5,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String var1=m.Groups[1].ToString();
                String c1=m.Groups[2].ToString();
                String ws1=m.Groups[3].ToString();
                String var2=m.Groups[4].ToString();
                String c2=m.Groups[5].ToString();
                Console.Write("("+var1.ToString()+")"+"("+c1.ToString()+")"+"("+ws1.ToString()+")"+"("+var2.ToString()+")"+"("+c2.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
