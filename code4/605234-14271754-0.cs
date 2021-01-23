    public static class InvalidResponseExceptionHelper
    {
        public static InvalidResponseException<TReq, TResp> Create<TReq, TResp>
            (string message, TReq requestData, TResp responseData)
        {
            return new InvalidResponseException<TReq, TResp>(message, 
                requestData, responseData);
        }
    }
