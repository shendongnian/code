    File.ReadAllLines("text.txt").Select(line =>
                {
                    var words = line.Split(' ');
                    var la = words.First().Take(2);
                    var mn = words.Skip(1).Select(s => s.First());
                    return new string(la.Concat(mn).ToArray()).ToUpper();
                }
               ); 
