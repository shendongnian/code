    public abstract class Question<TAnswer> where TAnswer : Answer
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public List<TAnswer> Answers { get; set; }
    }
    public class DateQuestion : Question<DateAnswer>
    {
        //...
    }
