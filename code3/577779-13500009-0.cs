    List<Question> newQuestionList = (from  q in dt.AsEnumerable()
                                                  where (q.Field<Guid>("Question") != null))
                                                  select new Question
                                                  {
                                                      Oid = q.Field<Guid>("Question"),
                                                      QuestionContext = q.Field<String>("QuestionContext"),
                                                      Priority = q.Field<Int32>("Priority"),
                                                      Order = q.Field<Int32>("OrderQuestion"),
                                                      Subject = q.Field<Guid>("Subject"),
                                                      Answers = (from a in dt.AsEnumerable()
                                                                 where a.Field<Guid>("Question") == q.Field<Guid>("Question")
                                                                 select
                                                                  new Answer
                                                                  {
                                                                      Oid = a.Field<Guid>("AnswerOid"),
                                                                      AnswerContext = a.Field<String>("Answer"),
                                                                      IsCorrect = a.Field<bool>("Correct")
                                                                  }).ToList()
                                                  }).GroupBy(n=>n.Oid).ToList();
