    public sealed class ValidNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ....check regex here...
        }
    }
