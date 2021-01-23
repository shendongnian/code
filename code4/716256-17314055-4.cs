    public IList<QuestionDto> GetQuestions(int subTopicId, int questionStatusId)
    {
        var questions = _questionsRepository.GetAll()
            .Where(a => a.SubTopicId == subTopicId &&
                   (questionStatusId == 99 ||
                    a.QuestionStatusId == questionStatusId))
            .Include(a => a.Answers)
            .ToList();
        var dto = questions.Select(x => new QuestionDto { Title = x.Title ... } );
        return dto; 
    }
