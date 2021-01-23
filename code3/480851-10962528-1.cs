        static void Main(string[] args)
        {
            var webRequest = WebRequest.Create("http://www.google.com");
            webRequest.BeginGetResponse(EndResponse, webRequest);
            Console.ReadLine();
        }
        static void EndResponse(IAsyncResult result)
        {
            var webRequest = (WebRequest) result.AsyncState;
            var response = webRequest.EndGetResponse(result);
            Console.WriteLine(new StreamReader(response.GetResponseStream()).ReadToEnd());
        }
