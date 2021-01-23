     //assuming your repo GetAll() returns a DbQuery<T>
     var questions = _questionsRepository.GetAll()
                    .Where(q=>q.SubTopic.Topic.SubjectId = mySubjectId)
                    .Include(q=>q.Answers)
                    .Include(q=>q.SubTopic.Topic)
                    .ToList();
