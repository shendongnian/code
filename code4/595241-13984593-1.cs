    static void Main(string[] args)
            {
                var lines = System.IO.File.ReadAllLines("lines.txt");
    
                var results = from line in lines
                         let tokens = line.Split(' ')
                         group tokens by tokens.First() into tokenGroup
                         select new
                         {
                             Terminal = tokenGroup.Key,
                             NonTerminals = tokenGroup.SelectMany(tokens => tokens.Skip(2))
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
