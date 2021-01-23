    int count = Math.Max(English.Count, Math.Max(Spanish.Count, German.Count));
    
    Enumerable.Range(0, count)
        .Select(num => new
        {
            Id = num + 1,
            English = English[num],
            Spanish = Spanish[num],
            German = German[num],
        });
