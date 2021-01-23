    public class ServicesViewModelValidator : AbstractValidator<ServicesViewModel>
    {
         public ServicesViewModelValidator()
         {
              RuleFor(x => x.ComponentTypeId)
                   .InclusiveBetween(1, int.MaxValue)
                   .WithMessage("Required");
    
              RuleFor(x => x.DomainId)
                   .NotNull()
                   .WithMessage("Required");
         }
    }
