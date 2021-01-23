    public IList<Question> GetQuestions(int subTopicId, int questionStatusId)
        {
            var questions = _questionsRepository.GetAll()
                .Where(a => a.SubTopicId == subTopicId &&
                       (questionStatusId == 99 ||
                        a.QuestionStatusId == questionStatusId))
                .Include(a => a.Answers).Select(b=> new { 
                   b.QuestionId,
                   b.Title
                   Answers = b.Answers.Select(c=> new {
                       c.AnswerId,
                       c.Text,
                       c.QuestionId }))
                .ToList();
            return questions; 
        }
