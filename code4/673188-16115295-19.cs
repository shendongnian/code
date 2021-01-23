    public class ResponseResult
    {
      public ResponseResult()
      {
      }
      public ResponseResult(ModelStateDictionary modelState)
      {
        this.ModelState = new ModelStateResult (modelState);
      }
      public bool IsValid { get; set; }
      public ModelStateResult ModelState { get; set; }
      public ResponseErrorBase Error { get; set; }
    }
