    public class MyWebFaultException<T>:WebFaultException<T>
    {
        public MyWebFaultException(T message)
            : base(message, HttpStatusCode.BadRequest)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
        }
    }
