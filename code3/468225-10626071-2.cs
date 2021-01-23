    public class YourClass
    {
        public static void Run(string address, Func<string, bool> callback)
        {                     
            Timer t = new Timer();
            t.Elapsed += delegate {                         
                var response = callURL(address);
             
                // if callback returns false, cancel timer
                if(!callback(response))
                {
                    t.Stop();
                }
            };          
            t.Interval = 3000;
            t.Start();                      
    }
    public class OtherClass
    {
        public bool ProcessResponse(string response)
        {
             // do whatever you want here to handle the response...
             // you can write it out, store in a queue, put in a member, etc.
             // check result to see if it's a certain value...
             // if it should keep going, return true, otherwise return false
        }
        public void StartItUp()
        {
             YourClass.Run("http://wwww.somewhere.net", ProcessResponse);
        }
    }
