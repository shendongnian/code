    namespace SoQna.Models
    {
        public class Question
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
        }
    
        public class Answer
        {
            public int AnswerId { get; set; }
            public Question Question { get; set; }
            public string AnswerText { get; set; }
        }
    }
