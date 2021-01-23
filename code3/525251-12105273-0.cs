    public static void InsertFeedbacks(IEnumerable<QuestionClass.Tabelfields> allList)
    {
        var fadd = from field in allList
                   select new Feedback
                              {
                                  Email = field.Email,
                                  QuestionID = field.QuestionID,
                                  Answer = field.SelectedOption
                              };
        context.Feedbacks.InsertAllOnSubmit(fadd);
        context.SubmitChanges();
    }
