                    ILookup<int, string> lookup =
                    list
                    .ToLookup(p => p.Id,
                              p => p.Name);
                foreach (IGrouping<int, string> group in lookup)
                {
                    Console.WriteLine(group.Key);
                    foreach (string name in group)
                        Console.WriteLine("    {0}", name);
                }
