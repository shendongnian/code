    public class ResultBase
    {
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
    public class RegisterResult : ResultBase
    {
        public Video Video{get;set;}
    }
