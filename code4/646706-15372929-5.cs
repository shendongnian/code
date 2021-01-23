    public class SearchModel: IValidatableObject
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhitespace(Field1) && string.IsNullOrWhitespace(Field2) && string.IsNullOrWhitespace(Field3))
                yield return new ValidationResult(("At least one field required.", new[] { "Field1", "Field2", "Field3" })
               
        }
    }
