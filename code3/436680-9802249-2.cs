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
            CheckVariables(response);
            // stuff
        }
    } 
