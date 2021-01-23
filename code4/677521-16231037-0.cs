    public class BusinessException : Exception
    {
      public int ErrorCode {get; private set;}
      public BusinessException(int errorCode)
      {
         ErrorCode = errorCode;
      }
    }
