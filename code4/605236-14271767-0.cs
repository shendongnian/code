    public  class InvalidResponseException<TReq, TResp> : Exception
    {
        public TReq RequestData { get; protected set; }
        public TResp ResponseData { get; protected set; }
    
        public InvalidResponseException (string message):
    	    this(message, default(TReq), default(TResp))	
        {
        }
        public InvalidResponseException (string message, TReq requestData, TResp responseData)  : base(message)
        {
    	    RequestData = requestData;
            ResponseData = responseData;
        }
       
    }
