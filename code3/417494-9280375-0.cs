    public class QuestionAnswer
    {
        [Key,ForeignKey("Question")]]
        public int AnswerID { get; set; }
    
        [ForeignKey("ModeratorReport"), Column(Order = 0)]
        public int ModeratorReportID { get; set; }
        [ForeignKey("ModeratorReport"), Column(Order = 1)]
        public string Status { get; set; }
    
        [ForeignKey("Section")]
        public int SectionID { get; set; }
    
   
        public string Answer { get; set; }
    
        public virtual ModeratorReport ModeratorReport { get; set; }
        public virtual Section Section { get; set; }
        public virtual Question Question { get; set; }
    }
