    var view = AnswerModels
        .Select(am => new
                          {
                              am.Question, 
                              Answers = string.Join("", am
                                                        .Answers
                                                        .Select(a => a.ToString())
                                                        .ToArray())
                          });
