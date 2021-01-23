    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace SO
    {
        static class Program
        {
            static void Main()
            {
                WebClient wc = new WebClient();
                var text = wc.DownloadString("http://projecteuler.net/project/names.txt");
                var names = Regex.Matches(text, "[A-Z]+").Cast<Match>()
                    .Select(x => x.Value)
                    .OrderBy(x => x)
                    .Select((name, inx) => new
                    {
                        Name = name,
                        Score = name.Sum(c => c - 'A' + 1) * (inx + 1)
                    });
                foreach (var n in names)
                {
                    Console.WriteLine("{0}: {1}", n.Name, n.Score);
                }
            }
        }
    }
