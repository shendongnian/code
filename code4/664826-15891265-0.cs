    public class ResultBase
    {
        public IEnumberable<ValidationResult> ValidationResults { get; set; }
        public T ResultObject
        {
          get;set;
        }
    }
    public class RegisterResult
    {
        public Video Video{get;set;}
    }
