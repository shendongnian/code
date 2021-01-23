    public class SingleErrorValidator<T> : AbstractValidator<T>
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var result = base.Validate(context);
            
            if (result.IsValid)
                return result;
            var singleErrorList = new List<ValidationFailure> { result.Errors.First() };
            var singleErrorResult = new ValidationResult(singleErrorList);
            return singleErrorResult;
        }
    }
