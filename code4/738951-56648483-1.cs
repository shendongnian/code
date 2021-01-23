    using (var db = new EFService())
    {
        var question= db.Question.Single(p => p.QuestionID == QuestionID);
        question.Answers.Add(a);
        question.Answers.Add(b);
        db.SaveChanges();
    }
