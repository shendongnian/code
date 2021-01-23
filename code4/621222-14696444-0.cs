    List<Question> QuestionsUnasweredByUser(User givenUser)
    {
        return AllOfTheQuestionsDb
               .Where(q => q.Answers
                            .Any(a => AllOfTheAnswersDb
                                      .Where(na => na.TheUserWhoAnswerd.Id != givenUser.Id)
                                      .ToList().Contains(a)))
               .ToList();
    }
    List<User> UserAssignedQuestions(bool answered)
    {
        return AllOfTheUsersDb
               .Where(u => u.Questions.Count > 0 && 
                           answered ? u.Questions.Any(q=> q.Answers.Count > 0) 
                                    : u.Questions.Any(q=>q.Answers.Count == 0)).ToList();
    }
    List<Question> OverdueQuestions(User givenUser, DateTime dueDate, bool answered)
    {
        return AllOfTheQuestionsDb
              .Where(q => (q.Answers.Count == 0 && !answered) || 
                           q.Answers.Any(a => a.TheUserWhoAnswerd.Id == givenUser.Id && 
                                              answered ? a.DateAnswered > dueDate  
                                                  : a.DateAnswered <= dueDate)).ToList();
    }
    List<Answer> OverdueAnswers(User givenUser, DateTime dueDate, bool answered)
    {
        return AllOfTheAnswersDb
              .Where(a => a.TheUserWhoAnswerd.Id == givenUser.Id && 
                          answered ? a.DateAnswered < dueDate 
                                   : a.DateAnswered <= dueDate).ToList();
    }
