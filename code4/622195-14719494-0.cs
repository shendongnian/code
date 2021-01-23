    public XmlReader RequestXML(string endpoint)
    {
        using (WebClient request = this.PrepareRequest(RestMethod.GET, null))
        {
            byte[] response = request.DownloadData(this.RestUrl + endpoint);
            MemoryStream responseStream = new MemoryStream(response);
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.CloseInput = true;
            return XmlReader.Create(responseStream, xmlReaderSettings);
        }
    }
