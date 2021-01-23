    var a = new Answer{
        Text = "AAA",
        QuestionId = 14
    };
    var b = new Answer
    {
        Text = "BBB",
        QuestionId = 14
    };
    dbContext.Answers.Add(a);
    dbContext.Answers.Add(b);
    dbContext.SaveChanges();
    // ...
