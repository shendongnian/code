    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = "source string to match with pattern";
              String matchpattern = @"(<target>(?:(?!<\/target>).)*?)(\/oem\/en(?=\/|\""))";
              String replacementpattern = @"$1~~~~~new value~~~~~";
              Console.WriteLine(Regex.Replace(sourcestring,matchpattern,replacementpattern,RegexOptions.IgnoreCase));
            }
        }
    }
