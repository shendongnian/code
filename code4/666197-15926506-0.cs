    public class Question
    {
        public int QuestionId { get; set; }
        public QuestionText Primary { get; set; }
        public ICollection<QuestionText> Alternatives { get; set; }
    }
    public class QuestionText
    {
        public int QuestionTextId { get; set; }
        public ICollection<QuestionTextVersion> Versions { get; set; }
        public QuestionTextVersion CurrentVersion { get; set; }
    }
    public class QuestionTextVersion
    {
        public int QuestionTextVersionId { get; set; }
        public int Version { get; set; }
        public string Text { get; set; }
    }
