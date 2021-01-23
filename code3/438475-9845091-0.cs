    string xml = "";
    using (var client = new WebClient())
    {
       xml  = client.DownLoadString("yourURL");   
    }
    // process the XML
