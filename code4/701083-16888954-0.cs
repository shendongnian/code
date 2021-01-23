    public IList<Model.question> GetAll(string search , string search1)
        {
            IList<Model.question> lstQuestions = context.questions.ToList();
            return lstQuestions.Where(a => a.TaskName.Contains(search) && a.ActivityID.Contains(search1)).ToList(); 
        }
