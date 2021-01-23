    static void Main(string[] args)
            {
                var lines = System.IO.File.ReadAllLines("lines.txt");
    
                var results = from line in lines
                             let tokens = line.Split(' ')
                             select new
                             {
                                 Terminal = tokens.First(),
                                 NonTerminals = tokens.Skip(2)
                             } into parsed
                             group parsed by parsed.Terminal into terminalGroup
                             select new
                             {
                                 Terminal = terminalGroup.Key,
                                 NonTerminals = terminalGroup.SelectMany(grp => grp.NonTerminals)
                             };
    
                foreach (var line in results)
                {
                    var sb = new StringBuilder(string.Format("{0} ->", line.Terminal));
                    foreach (var nonTerminal in line.NonTerminals)
                    {
                        sb.Append(string.Format(" {0}", nonTerminal));
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
