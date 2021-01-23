    public IList<Question> GetList()
    {
    	IList<Question> lstRecords = context.questions.ToList();
    	return lstRecords.GroupBy(x => new { x.QuestionNo, x.ActivityID }).Select(g => new Question(){ QuestionNo = g.Key.QuestionNo, ActivityID = g.Key.ActivityID, joined = string.Join(" ", g.Select(i => i.QuestionContent + "[" + i.Answer + "]"))}).Take(30).ToList();
    } 
