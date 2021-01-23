    var result = File.ReadAllLines("yourPath")
                .Select(line => DateTime.ParseExact(line, 
                          "yyyy-MM-dd HH:mm:ss", 
                          CultureInfo.CurrentCulture))
                .GroupBy(d => d.Date)
                .SelectMany(g =>
                        {
                            var orderedG = g.OrderBy(x => x);
                            var minMax = new[] {orderedG.Min(), orderedG.Max()};
                            return minMax;
                        });
                
