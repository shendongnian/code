    public class ResponseHandler<T>
    {
        public ResponseHandler(Action<T> typeSpecificCheckFunction)
        {
            this.CheckVariables = typeSpecificCheckFunction;
        }
        Action<T> CheckVariables;
        public void callResponseCallback(IAsyncResult asynchronousResult)
        {
            // stuff
            T regResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseData);
            CheckVariables(response);
            // stuff
        }
    } 
