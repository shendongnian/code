    [DataContract]
    public class ValidationType {}
    
    [DataContract]
    public class ValidationRule {}
    
    [DataContract]
    public class ValidationProperty {}
    
    [DataContract]
    [KnownType(typeof(NotNullValidatorRule))]
    public abstract class ValidatorBase {}
    
    [DataContract]
    public class NotNullValidatorRule : ValidatorBase {}
