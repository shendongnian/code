    public class MainService : Service
    {
        public GlobalState GlobalState { get; set; }
        public RespPing Any(ReqPing request)
        {
            // Add a value to a global list here
            GlobalState.AddData(myData);
    
            RespPing response = new RespPing();
            return response;
        }   
    }
