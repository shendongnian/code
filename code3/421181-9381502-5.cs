    [Validator(typeof(MyViewModelValidator))]
    public class MyViewModel
    {
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public DateTime DateToCompareAgainst { get; set; }
    }
    public class MyViewModelValidator : AbstractValidator<MyViewModel>
    {
        public MyViewModelValidator()
        {
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.DateToCompareAgainst)
                .WithMessage("Invalid start date");
        }
    }
