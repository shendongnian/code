    public abstract class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
    }
    public class ValueQuestion<T> : Question
    {
        public T CorrectValue { get; set; }
    }
    public class RangeQuestion<T> : Question
    {
        public T MinCorrectValue { get; set; }
        public T MaxCorrectValue { get; set; }
    }
    public class MultipleChoiceQuestion<T> : Question
    {
        public int NumberOfChoicesAllowed { get; set; }
        public List<MultipleChoiceOption<T>> Choices { get; set; }
    }
    public class MultipleChoiceOption<T>
    {
        public char Letter { get; set; }
        public bool Correct { get; set; }
        public T Value { get; set; }
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
        public List<IAnswer> Answers { get; set; }
    }
    public interface IAnswer
    {
        string QuestionId { get; set; }
        bool Correct { get; set; }
    }
    public class Answer<T> : IAnswer
    {
        public string QuestionId { get; set; }
        public bool Correct { get; set; }
        public T Value { get; set; }
    }
