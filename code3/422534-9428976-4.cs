    public class HttpListenerEventArgs : EventArgs
    {
        public readonly HttpListenerResponse response;
        public HttpListenerEventArgs(HttpListenerResponse httpResponse)
        {
            response = httpResponse;
        }
    }
