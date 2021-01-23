    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
    ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
    
    XmlDocument xml = new XmlDocument();
    XmlTextReader reader = new XmlTextReader(urlCommand);
    xml.Load(reader);
