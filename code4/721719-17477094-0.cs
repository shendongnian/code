    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ExistingFileNameAttribute : ValidationAttribute
    {
        public string FileFoundMessage { get; set; }
        public ExistingFileNameAttribute()
            : base("your default error message")
        {
            FileFoundMessage = "your default file exists message";
        }
        public override bool IsValid(object value)
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
