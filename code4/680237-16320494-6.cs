    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "11 22 33 1 2 3 1a 2b 3c a1 b2 c3  1a1a 2b2b 3b3b 1a1 2b2 3b3 a1a b2b c3c a b c aa bb cc";
              Regex re = new Regex(@"([0-9](?=[a-zA-Z])[a-zA-Z0-9]*|[a-zA-Z](?=[0-9])[a-zA-Z0-9]*)",RegexOptions.IgnoreCase);
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
                [0] => 1a
                [1] => 2b
                [2] => 3c
                [3] => a1
                [4] => b2
                [5] => c3
                [6] => 1a1a
                [7] => 2b2b
                [8] => 3b3b
                [9] => 1a1
                [10] => 2b2
                [11] => 3b3
                [12] => a1a
                [13] => b2b
                [14] => c3c
            )
    
        [1] => Array
            (
                [0] => 1a
                [1] => 2b
                [2] => 3c
                [3] => a1
                [4] => b2
                [5] => c3
                [6] => 1a1a
                [7] => 2b2b
                [8] => 3b3b
                [9] => 1a1
                [10] => 2b2
                [11] => 3b3
                [12] => a1a
                [13] => b2b
                [14] => c3c
            )
    
    )
