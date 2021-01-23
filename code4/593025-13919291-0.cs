    public class OurViewModel : IntlViewModelBase<OurResources>, IValidatableObject
    {
        public bool Validate(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
    public class MyViewModel : OurViewModel
    {
        public new bool Validate(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
