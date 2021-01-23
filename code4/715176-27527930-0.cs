    public static class Validator
    {
        public static IEnumerable<string> Validate(object o)
            {
                return TypeDescriptor.GetProperties(o.GetType()).Cast<PropertyDescriptor>().SelectMany(pd => pd.Attributes.OfType<ValidationAttribute>().Where(va => !va.IsValid(pd.GetValue(o)))).Select(xx => xx.ErrorMessage);
            }
        }
