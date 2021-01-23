    var data = new List<string>();
    data.Add("topic1 - subtopic1");
    data.Add("topic1 - subtopic2");
    data.Add("topic1 - subtopic3");
    data.Add("topic2 - subtopic4");
    data.Add("topic3 - subtopic5");
    var memo = new Dictionary<string, Topic>();
    foreach (var parts in data.Select(item => item.Split('-').Select(x=>x.Trim()).ToArray()))
    {
        if (!memo.ContainsKey(parts[0]))
        {
            memo.Add(parts[0], new Topic {Name = parts[0]});
        }
        memo[parts[0]].SubTopics.Add(new SubTopic { Name = parts[1], Topic = memo[parts[0]] });
    }
    var result = memo.Values.ToList();
