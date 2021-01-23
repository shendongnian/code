    string httpResponse = "";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
    WebResponse response = null;
    StreamReader reader = null;
    try
    {
        response = request.GetResponse();
    }
    catch (WebException ex)
    {
        response = ex.Response;
    }
    reader = new StreamReader(response.GetResponseStream());
    httpResponse = reader.ReadToEnd();
