     //Get all the possible questions in the database, with the count sent to zero
       var allPossible = _assessmentService.GetAll()
         .SelectMany(p => p.Answers).Select(x => new AnswerReport()
              {
                  AnswerCount = 0,
                  AnswerId = x.Id,
                  AnswerNumber = x.Number,
                  AnswerText = x.Text,
                  QuestionId = x.Question.Id,
                  QuestionText = x.Question.Title
              }).ToList();
    foreach (var answer in allPossible)
      {     
      /*  Warning: might be too complicated for Linq2Sql */
       answer.AnswerCount = _employeeService.GetAll()
       .Where(e => e.Store.Teams.Any(p => p.Team.Id.Equals(teamId)))
       .Where(e => e.Answers.Any(p => p.Answer.Id.Equals(answer.AnswerId)))
        .Select(a => new
               {
              AnswerInfo = a.Answers
                           .Select(p => new{
                                 AnswerId = answer.AnswerId,
                                 QuestionId = answer.QuestionId
                                 })
                                .FirstOrDefault(ans => 
                                 ans.QuestionId.Equals(answer.QuestionId))
                }).ToList()
                  //This .ToList() is yucky, but it's a problem with nhibernate
                 .Count(a => a.AnswerInfo.AnswerId.Equals(answer.AnswerId));
          }
