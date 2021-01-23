    var groups = lstRecords.GroupBy(x => new { x.QuestionNo, x.ActivityID, x.TaskID  }).Where(a => a.Key.TaskID == listTask && a.Key.ActivityID == listActivity);
    IList<Model.questionhint> questionHints = new List<Model.questionhint>();
    foreach(var group in groups)
    {
        questionHints.AddRange(group);
    }
    return questionHints;
