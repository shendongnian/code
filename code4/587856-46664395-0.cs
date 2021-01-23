    [DateCorrectRange(ValidateStartDate = true, ErrorMessage = "Start date shouldn't be older than the current date")]
    public DateTime StartDate { get; set; }
    
     [DateCorrectRange(ValidateEndDate = true, ErrorMessage = "End date can't be younger than start date")]
    public DateTime EndDate { get; set; }
