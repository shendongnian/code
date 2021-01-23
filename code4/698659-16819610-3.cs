    public interface IQuestion
    {
        string Title { get; }
    }
    
    public class ReportQuestion : IQuestion
    {
        public string Title { get { return ReportQuestionTitle; } }
    }
    
    public class ReportQuestionTranslation: IQuestion
    {
        public string Title { get { return ReportQuestionTitleTrans; } }
    }
    private void PopulateLabels(IQuestion item)
    {
        lblQuestionTitle.Text = item.Title;
    }
