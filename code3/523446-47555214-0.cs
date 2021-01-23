    public class AuditFilterAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }
    
        public AuditFilterAttribute() { }
    }
