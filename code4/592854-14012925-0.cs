    public class TestModelValidator : AbstractValidator<TestModel>
    {
        public TestModelValidator()
        {
            RuleFor(o => o.ParentVal).GreaterThan(0);
            RuleFor(o => o.Sub).SetValidator(new SubDataValidator());
        }
    }
    public class SubDataValidator : AbstractValidator<SubData>
    {
        public SubDataValidator()
        {
            RuleFor(o => o.SubDataVal).GreaterThan(0);
        }
    }
