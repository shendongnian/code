    public class YourValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //return based on conditions of "value"
        }
    }
