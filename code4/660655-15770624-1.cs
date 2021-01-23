    var results = input.Split(new[] { '\n' })
                       .GroupBy(x => x.Substring(0, 3))
                       .Select(g => g.ToList())
                       .SelectMany(g => g.Count > 1 ? g.Take(g.Count - 1).Concat(new[] { string.Format(">{0}", g[g.Count - 1]) }) : g)
                       .ToArray();
