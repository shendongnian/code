    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            string xyz = "text/plain; charset=US-ASCII; name=\"anythingfile.txt\"";
            Match m = Regex.Match(xyz, "name=\"(?<name>[^\"]+)\"");
            Console.WriteLine(m.Groups["name"].Value);
            Console.ReadKey();
        }
    }
