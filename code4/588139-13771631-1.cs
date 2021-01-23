    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var data = "=Short test...";
                var result = client.UploadString("http://localhost:52996/api/test", "POST", data);
                Console.WriteLine(result);
            }
        }
    }
