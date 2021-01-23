    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="1Dept Neurosci, The Univ. of New Mexico, ALBUQUERQUE, NM ";
    
          string re1="(\\d+)";	// Integer Number 1
          string re2="((?:[a-z][a-z]+))";	// Word 1
          string re3=".*?";	// Non-greedy match on filler
          string re4="((?:[a-z][a-z]+))";	// Word 2
          string re5="(,)";	// Any Single Character 1
          string re6="(.*?),";	// Command Seperated Values 1
    
          Regex r = new Regex(re1+re2+re3+re4+re5+re6,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String int1=m.Groups[1].ToString();
                String word1=m.Groups[2].ToString();
                String word2=m.Groups[3].ToString();
                String c1=m.Groups[4].ToString();
                String csv1=m.Groups[5].ToString();
                Console.Write("("+int1.ToString()+")"+"("+word1.ToString()+")"+"("+word2.ToString()+")"+"("+c1.ToString()+")"+"("+csv1.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
