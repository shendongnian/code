    public class Account
    {
        public int AccountId { get; set; }
    
        [Required(ErrorMessage = Constants.ValidationMessages.FieldRequired)]
        public string  Name { get; set; }
    
        public int? PrimaryUserId { get; set; }
        [ForeignKey("PrimaryUserId")]
        public Employer PrimaryUser { get; set; }
    
        [InverseProperty("Account")]
        public ICollection<Employer> Employers { get; set; }    
    }
