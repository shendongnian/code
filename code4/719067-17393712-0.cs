    class MyClass : IValidatableObject {
    
       public string Country { get; set; }
       
       [Required(ErrorMessage = "Postcode is required")]
       public string postcode { get; set;}
    
       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
          
          if (!String.IsNullOrEmpty(Country) 
             && !String.IsNullOrEmpty(postcode)) {
             
             switch (Country.ToUpperInvariant()) { 
                case "UK":
                   if (!Regex.IsMatch(postcode, "[regex]"))
                      yield return new ValidationResult("Invalid UK postcode.", new[] { "postcode" });
                   break;
    
                default:
                   break;
             }
          }
       }
    }
