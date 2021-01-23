    public class ResponseResult
    {
        public ResponseResult()
        {
        }
        public ResponseResult(ModelStateDictionary modelState)
        {
            this.ModelState = new ModelStateResult (modelState);
        }
        // Is this request valid, in the context of the actual request
        public bool IsValid { get; set; }
        // Serialized Model state if needed
        public ModelStateResult ModelState { get; set; }
    }
