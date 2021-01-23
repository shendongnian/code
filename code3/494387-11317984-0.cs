    var merged = list1.Concat(list2).Concat(list3)
        .Group(book => book.Name)
        .Select(g => new Book
        {
            Name = g.Key,
            Total = g.Sum(book => book.Total),
        })
        .ToList();
