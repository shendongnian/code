    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Proxy = null;   // set proxy here
    request.Timeout = 10000; 
    request.Method = "HEAD";
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        Console.WriteLine(response.StatusCode);
    }
