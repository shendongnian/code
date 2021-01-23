        public class MyViewModelValidator : AbstractValidator<MyViewModel>
        {
            public MyViewModelValidator()
            {
                RuleFor(x => x.SelectedOption).NotEmpty();
                RuleFor(x => x.Input1).NotEmpty().When(x => x.SelectedOption == "1");
                RuleFor(x => x.Input2).NotEmpty().When(x => x.SelectedOption == "1");
                RuleFor(x => x.RadioButtonValue).NotEmpty().When(x => x.SelectedOption == "2");
            }
        }
