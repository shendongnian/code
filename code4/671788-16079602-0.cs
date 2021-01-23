    public class CodeRangeRule : ValidationRule {
      public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        int strCode = -1;
        if (value != null && !Int32.TryParse(value.ToString(), out strCode))
          return new ValidationResult(false, "Illegal strCode");
        if (strCode < 9999 && strCode > 0) // Modify to suit your Validity Conditions
          return new ValidationResult(true, null);
        return new ValidationResult(false, "strCode is not within acceptable code range");
      }
    }
