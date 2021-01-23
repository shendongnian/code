    public class dsExpressionOfInterest
    {
        //Foreign key
        [Key, ForeignKey("dsRegistration")]
        public int dsExpressionOfInterestID { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public virtual dsRegistration dsRegistration { get; set; }
    }
