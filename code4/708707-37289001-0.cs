    public static class ValidatorExtensions
    {
        public static void ValidateAndThrowNotNull<T>(this IValidator<T> validator, T instance)
        {
            if (instance == null)
            {
                var validationResult = new ValidationResult(new[] { new ValidationFailure("", "Instance cannot be null") });
                throw new ValidationException(validationResult.Errors);
            }
            validator.ValidateAndThrow(instance);
        }
    }
