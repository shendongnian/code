    public class QuestionByAnyOfficial : AbstractIndexCreationTask<Question, QuestionByAnyOfficial.Result>
    {
        public class Result
        {
            public string Id;
            public bool AnyOfficial;
            public int SupportersCount;
            public DateTime CreatedOn;
        }
            
        public QuestionByAnyOfficial()
        {
            Map = questions => from question in questions                               
                               select new
                                  {
                                      Id = question.Id,                                              
                                      AnyOfficial = question.Answers.Any(a => a.IsOfficial),
                                      SupportersCount = question.Supporters.Count,
                                      CreatedOn = question.CreatedOn
                                  };            
        }
    }
            
    var questionIds = DocumentSession.Query<QuestionByAnyOfficial.Result, QuestionByAnyOfficial>()
                           .OrderByDescending(x => x.SupportersCount)
                           .ThenByDescending(x => x.AnyOfficial)
                           .ThenByDescending(x => x.CreatedOn)
                           .Take(NumberOfQuestions)
                           .Select(x => x.Id);
    var questions = DocumentSession.Load<Question>(questionIds);
    var result = questions.ToList();
