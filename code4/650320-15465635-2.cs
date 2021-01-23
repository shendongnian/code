        public class LoginModel
        {
            [Required]
            [EmailAddress]
            public string EmailAddress { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            [Compare("Password")]
            [Display(Name = "Confirm password")]
            public string ConfirmPassword { get; set; }
        }
    }
