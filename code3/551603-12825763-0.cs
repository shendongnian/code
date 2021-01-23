    public class id : IValidatableObject
        {
            [Required]
            public decimal l_ID { get; set; }
    
            [Required]
            public decimal v_ID { get; set; }
    
            private bool _hasBeenValidated = false;
    
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                
                if (!_hasBeenValidated)
                {
                    // validation rules go here. 
                    if (l_ID <= v_ID)
                        yield return new ValidationResult("Bad thing!", new string[] { "l_ID" });
                }
    
                _hasBeenValidated = true;
            }
        }
