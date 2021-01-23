    public interface IQuestionService
    {
        Question CurrentQuestion {get; set;}
    }
    public class QuestionService : IQuestionService
    {
        public Question CurrentQuestion {get; set;}
    }
