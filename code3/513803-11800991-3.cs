    public interface IError
    {
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }
    T TryExecute<T>(Func<T> action, int ErrorCode) where T : IError
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            result = Activator.CreateInstance<T>();
            result.ErrorMessage = ex.Message;
            result.ErrorCode = ErrorCode;
            return result;
        }
    }
