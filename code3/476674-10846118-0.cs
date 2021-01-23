    public class Registration
    {
        public String LoginName { get; set; }
 
        [Required]
        [StringLength(50, MinimumLength=10)]
        public String Password { get; set; }
 
        [Required]
        [StringLength(50, MinimumLength=10)]
        public String PasswordConfirm { get; set; }
    }
