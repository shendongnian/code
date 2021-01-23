    public IList<Question> GetQuestions(int subTopicId, int questionStatusId)
    {
        var questions = _questionsRepository.GetAll()
            .Where(a => a.SubTopicId == subTopicId &&
                        a.QuestionStatusId == questionStatusId)
            .Include(predicate)
            .ToList();
        return questions; 
    }
