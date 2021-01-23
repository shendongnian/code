    // Implementation of the Null Object pattern
    public class EmptyValidator<T> : IValidator<T>
    {
        public ValidationResult Validate(T instance)
        {
            return ValidationResult.ValidResult;
        }
    }
