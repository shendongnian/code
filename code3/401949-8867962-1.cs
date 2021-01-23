    public class TestModel:IValidatableObject
        {
            string MyDateTime{get;set;}
    
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                List<ValidationResult> v = new List<ValidationResult>();
                DateTime dt = default(DateTime);
                DateTime.TryParseExact(MyDateTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture,DateTimeStyles.None,out dt);
                if (dt.Equals(default(DateTime)))
                    v.Add(new ValidationResult("Invalid Date time"));
                return v;
            }
        }
