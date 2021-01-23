    class APICallResult
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
        public static async Task<APICallResult> APICall(int bla)
        {
            HttpResponseMessage response;
            bool res;
            // Post/GetAsync to server depending on call + other logic
            return new APICallResult { Success = res, StatusCode = response.StatusCode };
        }
