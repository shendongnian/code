    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              Regex re = new Regex(@"\[\S+\]");
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
