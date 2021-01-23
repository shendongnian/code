    public class JobCand
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int JC_ID { get; set; }
        public int Job_ID { get; set; }
        public int Candidate_ID { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        public string JC_Note { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P0}")]
        [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?$", ErrorMessage = "Invalid rate")]
        public decimal? JC_Skill_Match_Pct { get; set; }
    }
