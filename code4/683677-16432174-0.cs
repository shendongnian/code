    public interface IFaultException<out T>
    {
        T Detail { get; }
    }
    public class FaultException<T> : Exception, IFaultException<T>
    {
        private T _detail;
        public T Detail { get { return _detail; } }
        public FaultException(T detail, string message, Exception innerException)
        : base(message, innerException)
        {
           _detail = detail;
        }
    }
