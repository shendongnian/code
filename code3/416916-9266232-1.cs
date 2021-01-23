    var result = Enumerable.Range(0, 256)
        .Select(number => new
        {
            number,
            listIndexes = journeys
                .Select((list, index) => new { index, list })
                .Where(a => a.list.Contains(number))
                .Select(a => a.index)
                .ToList()
        })
        .Where(b => b.listIndexes.Count > 0)
        .ToList();
