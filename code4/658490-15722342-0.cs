    static void Main(string[] args)
    {
        WebRequest webRequest = HttpWebRequest.Create("http://www.forexfactory.com/ffcal_week_this.xml");
        // Only request the headers, not the whole content
        webRequest.Method = "HEAD";
        var response = webRequest.GetResponse();
        for (int i = 0; i < response.Headers.Count; i++)
        {
            Console.WriteLine(response.Headers.Keys[i] + " : " + response.Headers[i]);
        }
        Console.Read();
    }
