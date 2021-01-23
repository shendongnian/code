    public class VPerson : Person
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string VName { get; set; }
    
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(Settings.EmailRegex, ErrorMessage = "Email Address is not valid.")]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        public string VEmail { get; set; }
    
        public void SavePerson()
        {
            Name = VName;
            Email = VEmail;
            // update the DB
        }
    }
