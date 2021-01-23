    public class MyValidator : AbstractValidator<Person> {
      public MyValidator() {
        RuleFor(x => x.Name).NotNull();
      }
    
      protected override bool PreValidate(ValidationContext<Person> context, ValidationResult result) {
        if (context.InstanceToValidate == null) {
          result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));
          return false;
        }
        return true;
      }
    }
