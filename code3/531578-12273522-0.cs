            File.ReadAllLines("Utils.txt")
                .Select(s => new
                {
                    Name = s.Substring(1, s.IndexOf("]:") - 1),
                    Values = s.Substring(s.IndexOf(":") + 2)
                              .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                              .ToDictionary(l => l.Substring(1, l.IndexOf("]-") - 1),
                                            l => l.Substring(l.IndexOf("-[") + 2).Trim(']'))
                })
                .ToList()
                .ForEach(o =>
                    {
                        Console.WriteLine(o.Name);
                        o.Values.ToList().ForEach(p => Console.WriteLine(string.Format("\t{0}:\t{1}", p.Key, p.Value)));
                    });
