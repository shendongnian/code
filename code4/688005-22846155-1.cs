    var webRequest = (HttpWebRequest)WebRequest.Create(url);
    webRequest.Method = "GET";
    webRequest.ContentType = "application/json";
    webRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:28.0) Gecko/20100101 Firefox/28.0";
    webRequest.ContentLength = 0; // added per comment
    string autorization = "username" + ":" + "Password";
    byte[] binaryAuthorization = System.Text.Encoding.UTF8.GetBytes(autorization);
    autorization = Convert.ToBase64String(binaryAuthorization);
    autorization = "Basic " + autorization;
    webRequest.Headers.Add("AUTHORIZATION", autorization);
    var webResponse = (HttpWebResponse)webRequest.GetResponse();
    if (webResponse.StatusCode != HttpStatusCode.OK) Console.WriteLine("{0}",webResponse.Headers);
    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
    {
        string s = reader.ReadToEnd();
        Console.WriteLine(s);
        reader.Close();
    }
