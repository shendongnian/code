    public IList<Model.question> GetAll(string search , int search1)
        {
            IList<Model.question> lstQuestions = context.questions.ToList();
            return lstQuestions.Where(a => a.TaskName.Contains(search) && a.ActivityID==search1)).ToList(); 
        }
