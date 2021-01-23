    public class Question {
        public int Question_Id { get; set; }
        public string Question_Text { get; set; }
        public string Question_Help { get; set; }
        public string Question_Type { get; set; }
        [Display(Name = "Set ID")]
        public int Set_Id { get; set; }
        public Set Set { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
