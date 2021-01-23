    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	 public class DateRangeAttribute : ValidationAttribute
	 {
		  private readonly string _endDateProperty;
		  private readonly string _startDateProperty;
		  public DateRangeAttribute(string startDateProperty, string endDateProperty) : base()
		  {
				_startDateProperty = startDateProperty;
				_endDateProperty = endDateProperty;
		  }
		  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		  {
				var stP = validationContext.ObjectType.GetProperty(_startDateProperty);
				var enP = validationContext.ObjectType.GetProperty(_endDateProperty);
				if (stP == null || enP == null || stP.GetType() != typeof(DateTime) || enP.GetType() != typeof(DateTime))
				{
					 return new ValidationResult($"startDateProperty and endDateProperty must be valid DateTime properties of {nameof(value)}.");
				}
				DateTime start = (DateTime)stP.GetValue(validationContext.ObjectInstance, null);
				DateTime end = (DateTime)enP.GetValue(validationContext.ObjectInstance, null);
				if (start <= end)
				{
					 return ValidationResult.Success;
				}
				else
				{
					 return new ValidationResult($"{_endDateProperty} must be equal to or after {_startDateProperty}.");
				}
		  }
	 }
    class Tester
    {
        public DateTime ReportEndDate { get; set; }
    	[DateRange(nameof(ReportStartDate), nameof(ReportEndDate))]
    	public DateTime ReportStartDate { get; set; }
    }
