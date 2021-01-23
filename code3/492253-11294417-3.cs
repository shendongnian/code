        String Uri = "http://web.service.end.point"
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Uri);
        req.Headers.Add("SOAPAction", "\"http://tempuri.org/Register\"");
        req.ContentType = "text/xml;charset=\"utf-8\"";
        req.Accept = "text/xml";
        req.Method = "POST";
        String SoapMessage = "MySoapMessage, including envelope, header and body"
        using (Stream stm = req.GetRequestStream())
        {
            using (StreamWriter stmw = new StreamWriter(stm))
            {
                stmw.Write(SoapMessage);
            }
        }
        try
        {
            WebResponse response = req.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            log.InfoFormat("SoapResponse: {0}", sr.ReadToEnd());
        }
        catch(Exception ex)
        {
            log.Error(Ex.ToString());
        }
