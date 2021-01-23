    private string QueryServer(string command, Uri serverpage)
    {
        string qString = string.Empty;
        HttpWebRequest qRequest = (HttpWebRequest)HttpWebRequest.Create(serverpage.AbsoluteUri + "?q=" + command);
        qRequest.Method = "GET";
        qRequest.UserAgent = "MyAppName/1.1 (Instruction Request)";
        using (HttpWebResponse qResponse = (HttpWebResponse)qRequest.GetResponse())
            if (qResponse.StatusCode == HttpStatusCode.OK)
                using (System.IO.StreamReader qReader = new System.IO.StreamReader(qResponse.GetResponseStream()))
                    qString = qReader.ReadToEnd().Trim(); ;
        return qString;
    }
