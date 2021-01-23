    //Publisher class
    public class ValidateAbuse
    {        
        public delegate List<String> GetAbuseList();
        public static GetAbuseList Callback;
            
        public void Ip(string ip)
        {        
            foreach (GetAbuseList gal in Callback.GetInvocationList())
            {                
                List<string> result = gal.Invoke(/*any arguments to the parameters go here*/);
                //Do any processing on the result here
            }
        }            
    }
    //Subscriber class
    class Server
    {
    
            public static void Start()
            {
                //Use += to add to the delegate list
                ValidateAbuse.Callback += GetIpAbuseList;
                ValidateAbuse.Ip(MyIp);
            }
    
            private static List<string> GetIpAbuseList()
            {
                //return code goes here
                return new List<String>();
    }
