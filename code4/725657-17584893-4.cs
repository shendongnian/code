    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              Regex re = new Regex(@"^\#(?!\#)([^\r\n]*)(?=.*?^Subject=([^\r\n]*))(?=.*?^From=([^\r\n]*))(?=.*?^To=([^\r\n]*))(?=.*?^Read=([^\r\n]*))",RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.Singleline);
              Match m = re.Match(sourcestring);
              for (int gIdx = 0; gIdx < m.Groups.Count; gIdx++)
                {
                  Console.WriteLine("[{0}] = {1}", re.GetGroupNames()[gIdx], m.Groups[gIdx].Value);
                }
            }
        }
    }
