    List<Question> questions = 
        (from q in dt.AsEnumerable()
         where (q.Field<Guid>("Question") != null)
         group q by new {  Oid = q.Field<Guid>("Question"),
                           QuestionContext = q.Field<String>("QuestionContext"),
                           Priority = q.Field<Int32>("Priority"),
                           Order = q.Field<Int32>("OrderQuestion"),
                           Subject = q.Field<Guid>("Subject")
        } into g
        select new Question {
            Oid = g.Key.Oid,
            QuestionContext = g.Key.QuestionContext,
            Priority = g.Key.Priority,
            Order = g.Key.Order,
            Subject = g.Key.Subject,
            Answers = g.Select(a => new Answer() 
            {
                Oid = a.Field<Guid>("AnswerOid"),
                AnswerContext = a.Field<String>("Answer"),
                IsCorrect = a.Field<bool>("Correct")
            }).ToList()
        }).ToList();  
