    public class QuestionTitleFormatter
    {
        public string GetTitle(object question)
        {
            if(question is ReportQuestion)
                return ((ReportQuestion)question).ReportQuestionTitle;
            
            if(question is ReportQuestionTranslation)
                return ((ReportQuestionTranslation)question).ReportQuestionTitleTrans;
                
            throw new NotImplementedException(string.Format("{0} is not supported", questionType.Name);
        }
    }
    public void PopulateTitle(object question)
    {
        var formatter = new QuestionTitleFormatter();
        lblQuestionTitle.Text = formatter.GetTitle(question);
    }
