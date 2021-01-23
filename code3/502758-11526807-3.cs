    public class Answer
    {
        public Guid ID { get; set; }
        public Question Question { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class Question
    {
        public Guid ID { get; set; }
        public string QuestionText { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public bool MultipleAnswers { get; set; }
        public Question()
        {
            this.Answers = Enumerable.Empty<Answer>();
        }
    }
