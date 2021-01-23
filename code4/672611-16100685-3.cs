	public class TestModel : IValidatableObject
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Title == null)
			{
				yield return new ValidationResult("The title is mandatory.", new [] { "Title" });
			}
			if (Description == null)
			{
				yield return new ValidationResult("The description is mandatory.", new [] { "Description" });
			}
		}
	}
