	public class TestModel : IValidatableObject
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Title == null)
				yield return new ValidationResult("Title is required", new [] { "Title" });
			if (Description == null)
				yield return new ValidationResult("Description is required", new [] { "Description" });
		}
	}
