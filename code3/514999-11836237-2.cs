    public class FooRequired : FooBase
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = base.Validate(validationContext).ToList();
            result.AddRange(Foobar.Validate(validationContext));
            return result;
        }
    }
    public class FooNotRequired : FooBase
    {
        //No need to override the base validate method.
    }
