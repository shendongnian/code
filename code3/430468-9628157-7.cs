    internal class Program
    {
        private static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadLine();
        }
        
        public void Run()
        {
           var request = (HttpWebRequest)System.Net.WebRequest.Create("https://server-url-xxxx.com");
            request.Method = "POST";
            request.ProtocolVersion = System.Net.HttpVersion.Version10;
            request.ContentType = "application/x-www-form-urlencoded";
          
            using (var reqStream = request.GetRequestStream())
            {
                using(var response = new StreamReader(reqStream )
                {
                  Console.WriteLine(response.ReadToEnd());
                }
            }
        }
    }
