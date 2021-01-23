    public class DeliveryTracking : IValidatableObject
        {
            public string TrackingRef { get; set; }
            public string SalesID { get; set; }
            public string PackingSlipID { get; set; }
            public string Type { get; set; }
        }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
    { 
        if (Type ==typeOf(TNT) && TrackingRef.lenght <7
            return new ValidationResult("TrackingRef must be 7.");
        if(Type == typeOf(UPS ) && TrackingRef.lenght<8)
            return new ValidationResult("TrackingRef must be 8.");
    }
