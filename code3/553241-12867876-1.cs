    var comparer = new QuestionComparer();
    var newQuestions = UpdateList.Except(OriginalList, comparer).ToList();
    var both = from o in OriginalList
                           join u in UpdateList on o.Question equals u.Question
                           select new { o,u };
    var updatedQuestions = new List<Question>();
    foreach(var x in both)
    {
        if(x.u.AnswerHash != null && x.u.AnswerHash.Length != 0)
            updatedQuestions.Add(x.u);
        else
            updatedQuestions.Add(x.o);
    }
