    public class MultipleValidationResults : ValidationResult, IList<ValidationResult>
    {
        // stuff...
    }
    public ValidationResult Validate<T>(T t)
    {
        if (t is IEnumerable)
            // use reflection to call return ValidateList<Y>(t)
            // (T is IEnumerable<Y>)
        // other stuff
    }
    MultipleValidationResults ValidateList<T>(IEnumerable<T> entities);
