    public class Answers
    {
        [Key]
        public int asId { get; set; }  // use this property as PK
        public int Id { get; set; }  // because this is FK
        public string Text { get; set; }
    }
