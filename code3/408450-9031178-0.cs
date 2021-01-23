    public class WebFaultException<T> : WebFaultException
    {
        public WebFaultException(T content) : base(content)
        public T Content { get { return ObjContent; } }
    }
 
    public class WebFaultException
    {
        public WebFaultException(object content)
        {
            ObjContent = content;
        }
 
        public object ObjContent { get; private set; }
    }
