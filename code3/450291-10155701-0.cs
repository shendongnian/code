    protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
    {
        var viewModel = value as TimeInMinutesViewModel;
        if (viewModel == null)
        {
            //I don't know whether you need to handle this case, maybe just...
            return null;
        }
        if (viewModel.Hours != 0 || viewModel.Minutes != 0)
            return null;
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName)); 
    } 
