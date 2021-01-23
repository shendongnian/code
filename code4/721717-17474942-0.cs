    private const string DefaultFileNotFoundMessage = "Sorry but there is already an image with this name please rename your image";
    private const string DefaultErrorMessage = "Please enter a name for your image";
    public string FileNotFoundMessage { get; set; }
    protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
    {
        if (value!=null)
        {
            string fileName = value.ToString();
            if (FileExists(fileName))
            {
                return new ValidationResult(FileNotFoundMessage ?? DefaultFileNotFoundMessage);
            }
            else
            {
                return ValidationResult.Success;
            }  
        }
        else
        {
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
        }
    }
