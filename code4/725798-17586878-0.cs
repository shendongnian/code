    public IList<IGrouping<Tuple<int,int,int>,Model.questionhint>>
            GetRecords1(int listTask, int listActivity)
    {
        return context.questionhints
            .Where(a => a.TaskID == listTask && a.ActivityID == listActivity)
            .GroupBy(x => Tuple.Create(x.QuestionNo, x.ActivityID, x.TaskID))
            .ToList(); 
    }
