    public class CustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int number = value as int;
            return (number == 0 || (number >= 2500 && number <= 999999));
        }
    }
