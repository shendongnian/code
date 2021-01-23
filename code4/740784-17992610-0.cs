    public class YourClass
    {
        public static void Run(string address, Action<string> callback)
        {                     
            Timer t = new Timer();
            t.Elapsed += delegate {                         
                var response = callURL(address);
    
                callback(response);
            };          
            t.Interval = 5000;
            t.Start();                      
    }
    
    
    public class OtherClass
    {
        public void ProcessResponse(string response)
        {
             // do whatever you want here to handle the response...
             // you can write it out, store in a queue, put in a member, etc.
        }
    
    
        public void StartItUp()
        {
             YourClass.Run("http://wwww.somewhere.net", ProcessResponse);
        }
    }
