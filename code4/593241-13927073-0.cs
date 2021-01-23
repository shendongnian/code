    public class MyViewModel : OurViewModel, IValidatableObject
    {
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            //...
        }
    }
