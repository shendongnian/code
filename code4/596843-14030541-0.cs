    Please use below code to get the data in response string
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "GET";
        request.ContentType = "application/json";
        try
        {
            WebResponse webResponse = request.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        JObject objjson = JObject.Parse(response);
                        var obj= (from p in objjson["YourobjectList"].Children()
                                          select p).ToList();
                       
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
