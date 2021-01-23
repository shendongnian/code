    public class TestModel : ValidationRule
    {
        public bool IsChecked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (IsChecked)
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    return new ValidationResult(false, "FirstName requierd.");
                }
            }
            return new ValidationResult(true, null);
        }
    }
