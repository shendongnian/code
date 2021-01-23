    public class Bar : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (String.IsNullOrEmpty(Name))
                results.Add(new ValidationResult("Name is required", new[] { "Name" }));
            return results;
        }
    }
