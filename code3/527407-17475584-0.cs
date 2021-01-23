    public class QuestionAttempt
    {
        public ObjectId QId { get; set; }
        public long UserId { get; set; }
        [BsonElement("SN")]
        public string SkillName { get; set; }
        [BsonElement("IC")]
        public bool IsCorrect { get; set; }
    }
