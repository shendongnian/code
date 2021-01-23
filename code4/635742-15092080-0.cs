    public abstract class HttpListenerContextBase
    {
        public virtual HttpListenerRequestBase Request { get; private set; }
        public virtual HttpListenerResponseBase Response { get; private set; }
        public virtual IPrincipal User { get; private set; }
    }
