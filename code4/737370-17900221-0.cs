    _subTopicRepository
        .GetAll()
        .Where(s => s.Topic.SubjectId == subjectId)
        .Select(s => new TopicSubTopicSelect()
           {
              TopicId = s.TopidId,
              SubTopicId = s.SubTopicId,
              TopicName = s.Topic.Name,
              SubTopicName = s.Name
           })
        .ToList();
