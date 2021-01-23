    public class TweetHandler
    {
        public void Main()
        {
            ILogger logger = GetLogger();
        
            while (true)
            {
                ITweetReq request = GetNextRequest();
        
                ITweetRes response = HandleRequest(request, logger);
                
                SendResponse(response, logger);
            }
        }
        
        public ITweetRes HandleRequest(ITweetReq request, ILogger logger)
        {
            int id = request.Id;
            string text = request.Text;
        
            logger.Log("Received tweet " + id + " with text: " + text);
        
            return new TweetResponse(id, text);
        }
        
        public void SendResponse(ITweetRes response, ILogger logger)
        {
            logger.Log("Sending response to tweet: " + response.Id);
            Response(reponse);
        }
    }
