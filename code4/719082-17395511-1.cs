    AssessmentResponse = followers.FollowerEmployee
                                  .Where(a=>a.Answers != null && a.Answers
                                                                  .Where(a=>a.Answer.Question.IsPrimary)
                                                                  .Count > 0)
                                  .Answers
                                  .FirstOrDefault( a => a.Answer.Question.IsPrimary )
                                  .Answer
                                  .Number
                                  //Null Reference Exception 
