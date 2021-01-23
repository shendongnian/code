    public class ResponseResult<T> : ResponseResult
    {
        public ResponseResult() : base()
        {
        }
        public ResponseResult(ModelStateDictionary modelState)
            : base(modelState)
        {
        }
        public ResponseResult(T Data, ModelStateDictionary modelState)
            : base (modelState)
        {
            this.Data = Data;
        }
        public T Data { get; set; }
    }
