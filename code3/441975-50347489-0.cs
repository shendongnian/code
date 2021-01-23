    public class ServerRequest
    {
        public delegate void CallBackFunction(string input);
        public void DoRequest(string request, CallBackFunction callback)
        {
            // do stuff....
            callback(request);
        }
    }
