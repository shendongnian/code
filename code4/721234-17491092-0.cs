    var lstRecords = context.questionhints
    .Where(x => x.TaskID == listTask && x.ActivityID == listActivity)
    .GroupBy(x => new { x.QuestionNo, x.ActivityID, x.TaskID })
    .AsEnumerable()
    .Select(g => new QuestionHint()
            {
                QuestionNo = g.Key.QuestionNo,
                ActivityID = g.Key.ActivityID,
                TaskID = g.Key.TaskID,
                joined = String.Join(" ",
                           g.OrderBy(q => q.questionHintID)
                            .Select(i => i.QuestionContent + "[" + i.Answer + "]")),
                joinOption = String.Join(" ",
                           g.OrderBy(q => q.questionHintID)
                            .Select(a => "[" + a.Option1 + "," + a.Option2 + "]"))
    
            })
