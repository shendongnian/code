    public class LoginModel
      {
        [Required]
        [Display(Name = "Email Address:")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        [Required]  
        public string CaptchaText { get; set; }
    }
