    public class ResponseErrorBase
    {
       public int ErrorCode { get; set; }
       public string ErrorMessage { get; set; }
    }
    public class ResponseResult
    {
       ....
       ....
       public ResponseErrorBase Error { get; set; }
    }
