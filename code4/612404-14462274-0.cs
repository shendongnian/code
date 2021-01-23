    public abstract class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
    }
    public class ValueQuestion : Question
    {
        public object CorrectValue { get; set; }
    }
    public class RangeQuestion : Question
    {
        public object MinCorrectValue { get; set; }
        public object MaxCorrectValue { get; set; }
    }
    public class MultipleChoiceQuestion : Question
    {
        public int NumberOfChoicesAllowed { get; set; }
        public List<MultipleChoiceOption> Choices { get; set; }
    }
    public class MultipleChoiceOption
    {
        public char Letter { get; set; }
        public bool Correct { get; set; }
        public object Value { get; set; }
    }
    public class EssayQuestion : Question
    {
        public int MinAnswerLength { get; set; }
        public int MaxAnswerLength { get; set; }
    }
        
    public class Exam
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Taken { get; set; }
        public decimal Score { get; set; }
        public List<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public string QuestionId { get; set; }
        public bool Correct { get; set; }
        public object Value { get; set; }
    }
