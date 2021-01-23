    var separators = new[] { prefix, suffix };
    var firstResult = separators
        .SelectMany(s => subject
            .Split(separators,StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Reverse()
            .Skip(1)
            .Reverse())
        .Distinct()
        .ToList();
    var result = firstResult
        .Zip(firstResult.Skip(1), (a, b) =>
        {
            var l = new List<string>();
            separators.ToList().ForEach(s =>
            {
                l.Add(String.Format("{0}{1}{2}", a, s, b));
            });
            return l;
        })
        .SelectMany(s => s)
        .Union(firstResult)
        .ToList();
