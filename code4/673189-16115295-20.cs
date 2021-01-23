    // this isn't abstract because you may want to just return
    // non-specific error messages
    public class ResponseErrorBase
    {
      public int Code { get; set; }
      public string Message { get; set; }
    }
    public class InternalResponseError : ResponseErrorBase
    {
      // A Property that is specific to this error but
      // not for all Errors
      public int InternalErrorLogID { get; set; }
    }
