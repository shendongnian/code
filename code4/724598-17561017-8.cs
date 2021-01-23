    public class MyObject
    {
        public object MyValue { get; set; }
    }
    public class MyValidationRule : ValidationRule
    {
        public Type ObjectType { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
