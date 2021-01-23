    public abstract class Answer {
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
    }
    public class MultipleChoiceAnswer :Answer {
        //...
    }
    public class DateAnswer : Answer {
        //...
    }
