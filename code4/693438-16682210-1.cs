    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "A cat in a {{hat}} doesn't bite {back}.";
              Regex re = new Regex(@"[^{][{]([^}]*)[}][^}]");
              MatchCollection mc = re.Matches(sourcestring);
              int mIdx=0;
              foreach (Match m in mc)
               {
                for (int gIdx = 0; gIdx < m.Groups.Count; gIdx++)
                  {
                    Console.WriteLine("[{0}][{1}] = {2}", mIdx, re.GetGroupNames()[gIdx], m.Groups[gIdx].Value);
                  }
                mIdx++;
              }
            }
        }
    }
    
    $matches Array:
    (
        [0] => Array
            (
                [0] =>  {back}.
            )
    
        [1] => Array
            (
                [0] => back
            )
    
    )
