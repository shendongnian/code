    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              Regex re = new Regex(@"angle[(]Vector[(]\b([^,]*)\b[,]\b([^)]*)\b[)][,]Vector[(]\b([^,]*)\b[,]\b([^)]*)\b[)]",RegexOptions.IgnoreCase);
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
                [0] => angle(Vector(JointA,jointB),Vector(JointA,jointB)
            )
    
        [1] => Array
            (
                [0] => JointA
            )
    
        [2] => Array
            (
                [0] => jointB
            )
    
        [3] => Array
            (
                [0] => JointA
            )
    
        [4] => Array
            (
                [0] => jointB
            )
    
    )
