    public class SocialEvent : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Capacity < Attending)
            {
               var campo = new[] { "Capacity" }; 
               yield return new ValidationResult("Capacity cannot be less than number of confirmed attendees.", campo);  
            }
        }
    }
