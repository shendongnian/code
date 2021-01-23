    return _subTopicsRepository
                    .GetAll()
                    .Where(s => s.TopicId == topicId)
                    .Include(s => s.Topic)
                    .AsEnumerable()
                    .Select(item => new TopicSubTopic(item.TopicId,
                                                      item.SubTopicId,
                                                      item.Topic.Name,
                                                      item.Name))
                    .ToList();
