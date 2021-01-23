    public class CheckAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        object[] ValidValues;
        public CheckAttribute<T>(params T[] validValues)
        {
            ValidValues = validValues;
        }
        public override bool IsValid(object value)
        {
            return ValidValues.FirstOrDefault(v => v.Equals(value)) != null;
        }
    }
