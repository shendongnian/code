	public class featureModel : IValidatableObject
	{
		public FEATURE FEATURE { get; set; }
		public REQUIREMENTS REQUIREMENTS { get; set; }
		public bool FeaturesRequired { get; set; }
	
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (featuresRequired)
			{
				// do your feature check here
				if (FEATURE == null)
				{
					yield return new ValidationResult("You must enter a feature.");
				}
			}
		}
	}
