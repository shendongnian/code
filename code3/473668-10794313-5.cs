    public class Value<TValue> : IExceptional<TValue>
    {
        TValue _value = default(TValue);
        public Value(TValue value)
        {
            _value = value;
        }
        bool IExceptional<TValue>.IsException()
        {
            return false;
        }
        TValue IExceptional<TValue>.Value()
        {
            return _value;
        }
    }
    public class Exception<TValue, TException> : IInternalException, IExceptional<TValue> where TException : System.Exception
    {
        TException _exception = default(TException);
        public Exception(TException exception)
        {
            _exception = exception;
        }
        bool IExceptional<TValue>.IsException()
        {
            return true;
        }
        IExceptional<TOutValue> IInternalException.Copy<TOutValue>()
        {
            return _exception.ToExceptional<TOutValue,TException>();
        }
        TException GetException()
        {
            return _exception;
        }
        
        TValue IExceptional<TValue>.Value()
        {
            return default(TValue);
        }
    }
