    public class Question
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {
            if (Answers == null)
                Answers = new List<Answer>();
        }
    }
    public class Answer
    {
        public string Answer1 { get; set; }
    }
