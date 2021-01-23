    var result = 
    input.Aggregate(new List<List<string>>(),
                    (acc, s) =>
                    {
                        if (acc.Count == 0 || acc[acc.Count - 1].Count == 2)
                            acc.Add(new List<string>(2) { s });
                        else
                            acc[acc.Count - 1].Add(s);
                        return acc;
                    })
                    .Select(x => new KeyValuePair<string, string>(x[0], x[1]))
                    .ToList();
