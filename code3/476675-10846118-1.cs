    public class Registration : IValidatableObject
    {
        public String LoginName { get; set; }
        [Required]
        [StringLength(50, MinimumLength=10)]
        public String Password { get; set; }
 
        [Required]
        [StringLength(50, MinimumLength=10)]
        public String PasswordConfirm { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if(Password != PasswordConfirm)
                yield return new ValidationResult("Confirmation doesn't match", new[] {"PasswordConfirm"})
            //etc.
        }
    }
