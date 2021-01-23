    class Program {
        const string CONSUMER_KEY = "yours CONSUMER_KEY";
        const string CONSUMER_SECRET = "yours CONSUMER_SECRET";
        static void Main(string[] args)
        {
            Auth auth = new Auth(CONSUMER_KEY, CONSUMER_SECRET);
            
            auth.GetRequestToken();
         
            Console.WriteLine("Get PinCode from here.");
            Console.WriteLine(auth.GetAuthorizeUrl());
            Console.Write("PinCode：");
            string pin = Console.ReadLine().Trim();
            auth.GetAccessToken(pin);
     
        Console.WriteLine("AccessToken: " + auth.AccessToken);
        Console.WriteLine("AccessTokenSecret: " + auth.AccessTokenSecret);
        Console.WriteLine("UserId: " + auth.UserId);
        Console.WriteLine("ScreenName: " + auth.ScreenName);
 
      
            Console.WriteLine("yours status.");
            string status = Console.ReadLine();
            parameters.Clear();
            parameters.Add("status", auth.UrlEncode(status));
            Console.WriteLine(auth.Post("http://twitter.com/statuses/update.xml", parameters));
        }
    }
