    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MembershipHelper.MinRequiredPasswordLength )]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
