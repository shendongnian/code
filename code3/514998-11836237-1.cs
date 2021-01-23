    public abstract class FooBase : IValidatableObject
    {
        public string OtherProperty { get; set; }
 
        public Bar Foobar { get; set; }
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
    
            //Validate other properties here or return null
            if (String.IsNullOrEmpty(OtherProperty))
                results.Add(new ValidationResult("OtherProperty is required", new[] { "OtherProperty" }));
    
            return results;
        }
    }
