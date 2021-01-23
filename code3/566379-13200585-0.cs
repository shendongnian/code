    public interface IFoo
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public interface IBar
    {
        string Stuff { get; set; }
    }
    public class FooValidator : AbstractValidator<IFoo>
    {
        public FooValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
    public class BarValidator : AbstractValidator<IBar>
    {
        public BarValidator()
        {
            RuleFor(x => x.Stuff).Length(5, 30);
        }
    }
    public class FooBar : IFoo, IBar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stuff { get; set; }
    }
    public class CompositeValidatorRule : IValidationRule
    {
        private IValidator[] _validators;
        public CompositeValidatorRule(params IValidator[] validators)
        {
            _validators = validators;
        }
        #region IValidationRule Members
        public string RuleSet
        {
            get; set;
        }
        public IEnumerable<ServiceStack.FluentValidation.Results.ValidationFailure> Validate(ValidationContext context)
        {
            var ret = new List<ServiceStack.FluentValidation.Results.ValidationFailure>();
            foreach(var v in _validators)
            {
                ret.AddRange(v.Validate(context).Errors);
            }
            return ret;
        }
        public IEnumerable<ServiceStack.FluentValidation.Validators.IPropertyValidator> Validators
        {
            get { yield break; }
        }
        #endregion
    }
    public class FooBarValidator : AbstractValidator<FooBar>
    {
        public FooBarValidator()
        {
            AddRule(new CompositeValidatorRule(new FooValidator(), new BarValidator()));
        }
    }
