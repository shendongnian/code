    var surveys3 =  db.Surveys.Where( s => s.AccountId == appAcc.Id)
                                    .ToList()
                                    .Select( s => 
                                         new Survey {
                                              Id = s.Id,
                                              Title = s.Title,
                                              Description = s.Description,
                                              NumberOfQuestions = (from q in s.Questions
                                                         select q).Count()
                                               });
