     [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompareAndValidateAttribute : CompareAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && !string.IsNullOrEmpty((string)value);
        }
    }
