    WebRequest _request = (HttpWebRequest)WebRequest.Create("UrlToGet");
    using (WebResponse response = _request.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string text = reader.ReadToEnd();
        }
    }
