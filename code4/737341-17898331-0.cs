    var topics = new System.Collections.Generic.List<Topic>();
    var subTopics = new System.Collections.Generic.List<SubTopic>();
    int topicId = 23984;
    var details = from subtopic in subTopics
        where subtopic.TopicId == topicId
        join topic in topics on subtopic.TopicId equals topic.TopicId
        select new TopicSubTopic()
        {
            TopicId = topic.TopicId,
            SubTopicId = subtopic.SubTopicId,
            TopicName = topic.Name,
            SubtopicName = subtopic.Name
        };
