    var groups = generators.GroupBy(gen => gen.GetFirstName())
        .Select(group => new
        {
            Name = group.Key,
            Items = Task.WhenAll(group.Select(gen => gen.Generate()))
                .ContinueWith(t => t.Result.SelectMany(items => items).ToList())
        });
