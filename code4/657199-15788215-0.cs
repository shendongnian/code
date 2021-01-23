    public class DobViewModel
    {
       [DateTypeWithPhrase()]
       public string DateOfBirth { get; set; }    
    }
    
    public class DateTypeWithPhraseAttribute : DataTypeAttribute
    {
        public DateTypeWithPhraseAttribute() : base(DataType.Date)
        {
             ErrorMessageResourceName = null;
             ErrorMessage = ErrorPhrase;
        }
    
        public string ErrorPhrase = "Invalid Date";
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime myDate;
            if (value == null || DateTime.TryParse(value.ToString(), out myDate))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
     }
