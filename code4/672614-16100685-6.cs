	public class MyModel : IValidatableObject
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Title == null)
				yield return new ValidationResult("*", new [] { "Title" });
			if (Description == null)
				yield return new ValidationResult("*", new [] { "Description" });
		}
	}
