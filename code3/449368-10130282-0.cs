    var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");  
    myHttpWebRequest.MaximumAutomaticRedirections = 1;
    myHttpWebRequest.AllowAutoRedirect = true;
    var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();    
    using (var sw = new BinaryWriter(File.Open("image.jpg")))
    {
        using (var br = new StreamReader(myHttpWebResponse.GetResponseStream()))
        {
            sw.Write(br.ReadToEnd());
        }
    }
