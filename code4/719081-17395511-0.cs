    AssessmentResponse = followers.FollowerEmployee
                                  .Answers
                                  .First( a => a.Answer.Question.IsPrimary )
                                  .Answer
                                  .Number
                                  //Null Reference Exception 
