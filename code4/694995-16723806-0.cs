    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "for Module ID=\"107\" Can you h";
              Regex re = new Regex(@"\b(Module\s+ID=[\""](\d{1,})[\""])",RegexOptions.IgnoreCase);
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
                [0] => Module ID="107"
            )
    
        [1] => Array
            (
                [0] => Module ID="107"
            )
    
        [2] => Array
            (
                [0] => 107
            )
    
    )
