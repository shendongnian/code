    context.Questions
    .Where(q=>q.SubTopic.Topic.SubjectId = mySubjectId)
    .Include(q=>q.Answers)
    .Include(q=>q.SubTopic.Topic)
    .ToList();
