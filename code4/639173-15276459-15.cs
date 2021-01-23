    public class TempValidationRule : ValidationRule
    {
        // default values
        private int _minimumTemp = -273;
        private int _maximumTemp = 2500;
        public int MinimumTemp
        {
            get { return _minimumTemp; }
            set { _minimumTemp = value; }
        }
        public int MaximumTemp
        {
            get { return _maximumTemp; }
            set { _maximumTemp = value; }
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string error = null;
            string s = GetBoundValue(value) as string;
            if (!string.IsNullOrEmpty(s))
            {
                int temp;
                if (!int.TryParse(s, out temp))
                    error = "No valid integer";
                else if (temp > this.MaximumTemp)
                    error = string.Format("Temperature too high. Maximum is {0}.", this.MaximumTemp);
                else if (temp < this.MinimumTemp)
                    error = string.Format("Temperature too low. Minimum is {0}.", this.MinimumTemp);
            }
            return new ValidationResult(string.IsNullOrEmpty(error), error);
        }
        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;
                // Get the bound object and name of the property
                string resolvedPropertyName = binding.GetType().GetProperty("ResolvedSourcePropertyName", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).GetValue(binding, null).ToString();
                object resolvedSource = binding.GetType().GetProperty("ResolvedSource", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).GetValue(binding, null);
                // Extract the value of the property
                object propertyValue = resolvedSource.GetType().GetProperty(resolvedPropertyName).GetValue(resolvedSource, null);
                return propertyValue;
            }
            else
            {
                return value;
            }
        }
    }
