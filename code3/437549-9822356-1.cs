     public class Issue
     {
        [Key]
        public int IssueID { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modiefied { get; set; }
        public int PriorityID { get; set; }
        public int CategoryID { get; set; }
