    public class ClassifiedRating
    {
        [Key, Column(Order = 0)]
        public int RaterId { get; set; }
        [Key, Column(Order = 1)]
        public int ClassifiedId { get; set; }
        public User Rater {get;set;}
        public Classified Classified { get; set; }
        public int rating { get; set; }
    }
