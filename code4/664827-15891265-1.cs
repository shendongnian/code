    public class ServiceResult<T>
    {
        public IEnumberable<ValidationResult> ValidationResults { get; set; }
        public T ResultObject
        {
          get;set;
        }
    }
