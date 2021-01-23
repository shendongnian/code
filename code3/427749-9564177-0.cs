    public sealed class ValidationError
    {
        public Validator Validator { get; set; }
        public string PropertyName { get; set; }
        public object AttemptedValue { get; set; }
    }
