    var lines = File.ReadLines(prnFile, Encoding.GetEncoding(1250))
                    .Skip(1)
                    .SelectMany(line => line.Split(new[] { "  " }, 
                                              StringSplitOptions.RemoveEmptyEntries))
                    .ToList();
