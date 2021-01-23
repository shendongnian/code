    public class Category : IValidatableObject
    {
        public int? Id{ get; set; }
    
        [DisplayName("Father Category")] //NOT REQUIRED
        public Category Father { get; set; }
    
        [DisplayName("Category")]
        [Required(ErrorMessage = "Name is required")] //REMEMBER THIS REQUIRED PROPERTY!!
        public string Name { get; set; }
    
        [DisplayName("Status")]
        public bool Status { get; set; }
    
        [DisplayName("Description")]
        public string Description { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (this.Enable)
            {
                Validator.TryValidateProperty(this.Name ,
                    new ValidationContext(this, null, null) { MemberName = "Name" },
                    results);
                Validator.TryValidateProperty(this.Status,
                    new ValidationContext(this, null, null) { MemberName = "Status" },
                    results);
            }
            return results;
        }
    }
    
    public void Validate()
    {
            var toValidate = new Category()
            {
                Name = "Just a name",
                Status = true
            };
    
            bool validateAllProperties = false;
    
            var results = new List<ValidationResult>();
    
            bool isValid = Validator.TryValidateObject(
                toValidate,
                new ValidationContext(toValidate, null, null),
                results,
                validateAllProperties);
    }
