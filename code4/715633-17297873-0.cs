    public class Answer : AuditableTable
    {
        public bool Correct { get; set; }
        public bool Response { get; set; }
        public YourClassName Text { get; set; }
        public string ImageFile { get; set; }
        public YourClassName Explanation { get; set; }
    }
