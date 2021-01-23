    int UserA = 1;
    // For a given user - UserA -, return all questions where UserA did not answer that question
    // Look for questions where the count of UserA appearances is zero.
    List<Question> NotAnsweredByUserA = AllOfTheQuestionsDb.Where(a => a.Answers.Count(b => b.TheUserWhoAnswerd.Id == UserA) == 0).ToList();
    // For all questions in system, return all users that the question was assigned to but that user did/didn't answer
    // Look for answers in questions where a User has been assigned, but no answer, and select that user
    List<User> NotAnsweredButAssigned = AllOfTheQuestionsDb.SelectMany(a => a.Answers.Where(b => b.TheUserWhoAnswerd != null && string.IsNullOrWhiteSpace(b.UserAnswer)).Select(c => c.TheUserWhoAnswerd)).ToList();
    // Selecting questions and answers for a user that were not answered after a given date
    // Select the questions where the answer contains an answer date before today and answered by UserA
    List<Question> NotAnsweredBeforeDate = AllOfTheQuestionsDb.Where(a=>a.Answers.Any(b=>b.DateAnswered < DateTime.Now && b.TheUserWhoAnswerd.Id == UserA)).ToList();
