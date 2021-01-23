    Dictionary<string,Topic> topics = new Dictionary<string,Topic>();
    foreach(string topic in data)
    {
    string[] values = topic.split(new string[]{"-"});
    if( !topic.ContainsKey(values[0]) )
      topic.Add(values[0], new Topic());
    Topic topic = topics [values[0];
    topic.Name = values[0];
    topic.SubTopics.Add( new SubTopic(){Name = values[1]};
    }
