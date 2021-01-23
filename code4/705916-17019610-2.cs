    var result = File.ReadAllLines("yourPath")
                .Select(line => DateTime.ParseExact(line, 
                                       "yyyy-MM-dd HH:mm:ss", 
                                        CultureInfo.CurrentCulture))
                .GroupBy(d => d.Date)
                .SelectMany(g => new[] { g.Min(), g.Max() });
                
