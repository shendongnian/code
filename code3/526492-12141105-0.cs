    public class StartEndDate: IValidatableObject
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]    
        public DateTime EndDate { get; set; } 
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           // do the validations
        }
    }
