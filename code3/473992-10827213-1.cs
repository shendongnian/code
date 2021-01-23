    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
    WebRequest request = WebRequest.Create("http://my.ooma.com/");
    string htmlResponse = string.Empty;
    using (WebResponse response = request.GetResponse())
    {
         using (StreamReader reader = new StreamReader(response.GetResponseStream()))
         {
             htmlResponse = reader.ReadToEnd();
             reader.Close();
         }
         response.Close();
    }
