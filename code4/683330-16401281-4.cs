    public interface ISomeInterface<T>
    {
        ValidationResult Validate(T t);
        IList<ValidationResult> ValidateList(IEnumerable<T> entities);
    }
