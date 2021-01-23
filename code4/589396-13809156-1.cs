    [Required]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
    [Display(Name = "Payment Amount:")]
    [Range(0.01, Double.MaxValue)]
    public decimal Amount { get; set; }
