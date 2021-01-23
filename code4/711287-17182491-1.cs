    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              Regex re = new Regex(@"^(?<pol>[0-9a-zA-Z]+)[^a-zA-Z0-9](?<fac>[0-9a-zA-Z]+\s[0-9a-zA-Z]+-[0-9a-zA-Z]+)[^a-zA-Z0-9](?<end>[0-9a-zA-Z]+)[^a-zA-Z0-9](?<op>[0-9a-zA-Z]+)",RegexOptions.IgnoreCase | RegexOptions.Multiline);
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
