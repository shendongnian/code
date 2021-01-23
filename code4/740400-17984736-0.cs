    var separator = new[] { "-" };
    var topics = data.Select(s => s.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        .GroupBy(strings => strings[0])
        .Select(grouping => new Topic
        {
            Name = grouping.Key,
            SubTopics = grouping.Select(s => new SubTopic {Name = s[1]}).ToList()
        })
        .ToArray();
