    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]`enter code here`
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
