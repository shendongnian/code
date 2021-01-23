    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public virtual ICollection<Answer> Answers { get; set; }
    }
