    var topics = from topic in context.Topics
                select
                    new {
                            Topic = topic,
                            NumberOfMessages = topic.Messages.Count()
                        };
    var topicWith = topics.FirstOrDefault();
    topicWith.Topic.NoOfViews++;
    context.Topics.Add(topicWith.Topic);
