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
