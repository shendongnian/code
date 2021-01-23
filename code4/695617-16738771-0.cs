    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              Regex re = new Regex(@"<meta\b[^>]*\bname=[""]keywords[""][^>]*\bcontent=(['""]?)((?:[^,>""'],?){1,})\1[>]",RegexOptions.IgnoreCase);
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
                [0] => <meta name="keywords" content="Keyword1, Keyword2, Keyword3...">
            )
    
        [1] => Array
            (
                [0] => "
            )
    
        [2] => Array
            (
                [0] => Keyword1, Keyword2, Keyword3...
            )
    
    )
