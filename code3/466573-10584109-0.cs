    void Main()
    {
        var request = (HttpWebRequest)WebRequest.Create("http://128.75.49.209/response.php");
        request.Method = WebRequestMethods.Http.Post;
        request.ContentType = "application/x-www-form-urlencoded";
        using (var stream = request.GetRequestStream())
        {
            var buffer = Encoding.UTF8.GetBytes("name=asd&pass=asd&country=82&btn=Submit+Query");
            stream.Write(buffer,0,buffer.Length);
        }
        var response = (HttpWebResponse)request.GetResponse();
        string result = String.Empty;
        using (var reader = new StreamReader( response.GetResponseStream()))
        {
            result = reader.ReadToEnd();
        }
        Console.WriteLine(result);
