    public class MainService : Service
    {
        static List<MyData> myList = new List<MyData>();
        public RespPing Any(ReqPing request)
        {
            // Add a value to a global list here
            lock(myList) myList.Add(myData);
    
            RespPing response = new RespPing();
            return response;
        }   
    }
