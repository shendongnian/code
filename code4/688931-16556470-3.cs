    using System;
 
    public class Test
    {
        public static void Main()
        {
            string source = "//uncomment me" + Environment.NewLine + "//line two.";
            string[] lines = source.Split('\r', '\n');
            foreach (string line in lines)
            {
                Console.WriteLine(line.Replace("//", ""));
            }
        }
    }
