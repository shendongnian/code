    public class Sender
    {
        public void Send(string Message)
        {
        ...
            WebRequest myReq = GetRequest(sParmeter);
        }
        
        protected virtual WebRequest GetRequest(string URl)
        {
            return WebRequest.Create(URl);
        }
    }
