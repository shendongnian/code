    string input = "3, 7, 12-14, 1, 5-6";
    List<int> all = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(r => new
        {
            Range = r,
            Parts = r.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(p => int.Parse(p))
        })
        .SelectMany(x => Enumerable.Range(x.Parts.First(), 1 + x.Parts.Last() - x.Parts.First()))
        .ToList();
