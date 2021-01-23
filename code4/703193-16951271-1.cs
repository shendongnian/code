    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "sample text above";
              Regex re = new Regex(@"\{((?:\{(?:\{.*?\}|.)*?\}|.)*?)\}",RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
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
                [0] => {a}
                [1] => {a:b}
                [2] => {a:{b}}
                [3] => {a:{b:c}}
                [4] => {a}
                [5] => {b}
                [6] => {a}
                [7] => {b}
                [8] => {c}
                [9] => {a{b{c}}}
                [10] => {{{d}e}f}
            )
    
        [1] => Array
            (
                [0] => a
                [1] => a:b
                [2] => a:{b}
                [3] => a:{b:c}
                [4] => a
                [5] => b
                [6] => a
                [7] => b
                [8] => c
                [9] => a{b{c}}
                [10] => {{d}e}f
            )
    
    )
