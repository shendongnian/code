    public IList<Topic> createTopics(string subjectName)
    {
        var topics = from o in GetContent.GetType6()
                     select new Topic
                     {
                        Name = o.Item1,
                        SubTopics = o.Item2.Split('\n')
                                           .Select(x => new SubTopic { Name = x})
                                           .ToArray();
                     };
         return topics.ToList();
    }
