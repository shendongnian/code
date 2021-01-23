    [Validator(typeof(ActivityLineValidator))]
    public class ActivityLine
    {
        [Key]
        [Required]
        public int ActivityLineId { get; set; }
    
        public virtual ICollection<TimeModel> TimeModels { get; set; }
    }
    
    public class ActivityLineValidator : AbstractValidator<ActivityLine>
    {
        public ActivityLineValidator()
        {
            RuleFor(x => x.TimeModels).SetCollectionValidator(new TimeModelValidator());
        }
    }
