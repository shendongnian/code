    // Implementation of the Composite pattern
    public class CompositeValidator<T> : IValidator<T>
    {
        private readonly IEnumerable<Validator<T>> col;
        public CompositeValidator(IEnumerable<Validator<T>> col)
        {
            this.col = col;
        }
        public ValidationResult Validate(T instance)
        {
            ValidationResult total = ValidationResult.ValidResult;
            foreach (var validator in this.col)
            {
                var result = validator.Validate(instance);
                total = ValidationResult.Append(total, result);
            }
            return total;
        }
    }
