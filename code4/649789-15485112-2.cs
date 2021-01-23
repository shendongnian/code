    var tags = context.Tags
        .Where(t => t.Content is Image && !(t.Content as Image).Private)
        .Select(t => new
        {
            Tag = t,
            Image = t.Content as Image, // possibly this line is not needed
            Author = (t.Content as Image).Author,
            Person = t.Person
        })
        .AsEnumerable()
        .Select(x => x.Tag)
        .ToList();
