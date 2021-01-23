    public class Question
     {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
    
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
