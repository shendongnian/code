	public class Address : IValidatableObject
	{
		[Required]
		public string Name { get; set; }
		public string Country { get; set; }
		public string ZipCode { get; set; }
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();
			switch (Country)
			{
				case "France":
					if (ZipCode.Length < 8)
						results.Add(
							new ValidationResult("French zip codes must be at least 8 characters", new List<string> { "ZipCode" })
						);
					break;
				case "U.S.":
					if (ZipCode.Length < 10)
						results.Add(
							new ValidationResult("American zip codes must be at least 10 characters", new List<string> { "ZipCode" })
						);
					break;
				// Etc.
			}
			return results;
		}
	}
