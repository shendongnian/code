    list.Where(f => f.Elements.Any(s => s.Is))
        .Select(f => new firstClass() {
                                          Id = f.Id,
                                          Elements = f.Elements.Where(s => s.Is)
                                                               .ToList()
        }).ToList();
