    public class Quizs
    {
        // no attribute
        public virtual ICollection<Question> Questions { get; set; }
    }
    
    public class Question
    {
        // no attribute
        public virtual ICollection<Answers> Answers { get; set; }
        // add
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quizs Quiz { get; set; }
    }
    public class Answers
    {
        // add
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
