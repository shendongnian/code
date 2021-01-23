    public abstract class MinMaxValidatorBase
    {
        // do common stuff here 
        public abstract bool Validate(object value);
    }
    // Create a own Attribute so the currect Validator can be found
    [ValidatorType(typeof(int))]     
    public class Int32MinMaxValidator : MinMaxValidatorBase
    {
      // validate int here
    }
    [ValidatorType(typeof(string))]  
    public class StringMinMaxValidator : MinMaxValidatorBase
    {
       // validate string here
    }
    public void ValidateValue(object value)
    {
       // Validator loader gets the right MinMaxValidator with reflection 
       // based on the value type mapped with the ValidatorType attribute
       MinMaxValidatorBase validator = ValidatorLoader.GetValidator(value);
       bool isValid = validator.Validate(value);
    }
