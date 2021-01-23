    HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(@"validURL");
    httpWebRequest.Method = "GET";
    httpWebRequest.BeginGetResponse((asyncresult) =>
    {
        try
        {
            WebResponse webResponse = httpWebRequest.EndGetResponse(asyncresult);
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader Reader = new StreamReader(stream);
                string response = Reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            exception(ex);
        }
    }, httpWebRequest);
