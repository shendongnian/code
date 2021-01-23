    public class ApplicationNotFoundException : CustomException 
    {
        public ApplicationNotFoundException(Application application)
        {
            string message = string.Format(@"Application '{0}' was not found", application.ApplicationName);
            base.ErrorMessage = message
            base.HttpStatusCode = HttpStatusCode.NotFound;
        }
    }
    public class CustomException : Exception
    {
        public string ErrorMessage { get; internal set; }
        public HttpStatusCode HttpStatusCode { get; internal set; }
    
        public CustomException(string errorMessage)
            : this(errorMessage, HttpStatusCode.InternalServerError)
        { }
    
        public CustomException(string message, HttpStatusCode httpStatusCode)
        {
            ErrorMessage = message;
            HttpStatusCode = httpStatusCode;
        }
    }
