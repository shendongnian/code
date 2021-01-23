    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ExistingFileNameAttribute : ValidationAttribute
    {
        public string FileFoundMessage = "Sorry but there is already an image with this name please rename your image";
        public ExistingFileNameAttribute()
            : base("Please enter a name for your image")
        {            
        }
        public override ValidationResult IsValid(object value)
        {
            if (value!=null)
            {
                string fileName = value.ToString();
                if (FileExists(fileName))
                {
                    return new ValidationResult(FileFoundMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }  
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
