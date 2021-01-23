    public class Question {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public IList<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
    }
    public class Answer {
        public int Id { get; set; }
        public string Text { get; set; }
    }
