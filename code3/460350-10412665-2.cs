    public XmlDocument GetDataFromUrl(string url)
    {
        XmlDocument urlData = new XmlDocument();
        HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(url);
        rq.Timeout = 60000;
        HttpWebResponse response = rq.GetResponse() as HttpWebResponse;
        using (Stream responseStream = response.GetResponseStream())
        {
            XmlTextReader reader = new XmlTextReader(responseStream);
            urlData.Load(reader);
        }
        return urlData;
    }
