    public IList<Model.questionhint> GetRecordsPlease(int listTask, int listActivity)
    {
        return context.questionhints
                      .Where(a => a.TaskID == listTask && a.ActivityID == listActivity)
                      .ToList();
    }
