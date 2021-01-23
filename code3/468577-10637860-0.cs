    class Company
    {
        [Required]
        [StringLength(40)]
        [RegularExpression(@"someregexhere")]
        public string CompanyName { get; set; }
    }
