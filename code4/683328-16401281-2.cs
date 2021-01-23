    public class SomeClass<T> : ISomeInterface<T>
    {
        ValidationResult Validate(T t)
        {
            // Do something ...
        }
        IList<ValidationResult> ValidateList(IEnumerable<T> entities)
        {
            // Do something ...
        }
    }
