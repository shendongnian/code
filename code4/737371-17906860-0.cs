    return _subjectsRepository
            .Get(subjectId)
            .SelectMany(subject => subject.SubTopics))
            .Select(subTopic => new TopicSubTopicSelect
            {
                TopicId = subTopic.TopicId,
                SubTopicId = subTopic.SubTopicId,
                TopicName = subTopic.Topic.Name,
                SubTopicName = subTopic.Name
            }).ToList();
