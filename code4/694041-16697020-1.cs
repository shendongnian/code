    public class MyClass : IValidatableObject
    {
        public string MyString { get; set; }
        // ... Other fields ...
    
        public virtual IEnumerable<ValidationResult> Validate(
                                                     ValidationContext validationContext)
        {
            if (!String.IsNullOrEmpty(MyString))
            {
                if(MyString.Length != 6)
                {
                    // ... Validation rules ...
                    yield return new ValidationResult("MyString must be 6 chars long",
                                                       new[] { "MyString" });
                }
            }
        }
    }
