    public class CompanyViewModel
    {
        public new Guid ID { get; set; }
    
        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }    
    }
