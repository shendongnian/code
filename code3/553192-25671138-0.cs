    WebResponse webResponse = webRequest.GetResponse();
    String response = null;
    using(var strReader = new StreamReader(webResponse.GetResponseStream()))
    {
        response = streamReader.ReadToEnd();
    }
