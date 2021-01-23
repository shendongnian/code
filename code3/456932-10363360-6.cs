    using System.Collections.Generic;
    
    namespace SoQna.ViewModels
    {
        public class QnaViewModel
        {
            public IList<AnswerToQuestion> Answers { get; set; }
        }
    
        public class AnswerToQuestion
        {
            public int ToQuestionId { get; set; }
            public string QuestionText { get; set; }
            public string AnswerText { get; set; }
        }
    }
