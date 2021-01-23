    public void logoutOfEM(string deviceName)
        {
            string lgRequest = "xml=<request>";
                   lgRequest += "<appInfo>";
                   lgRequest += "<appID>" + appID + "</appID>";
                   lgRequest += "<appCertificate>" + appCertificate + "</appCertificate>";
                   lgRequest += "</appInfo>";
                   lgRequest += "<logout>";
                   lgRequest += "<deviceName>";
                   lgRequest += deviceName;
                   lgRequest += "</deviceName>";
                   lgRequest += "</logout>";
                   lgRequest += "</request>";
         using (Stream str = req.GetRequestStream())
        {
            str.Write(System.Text.Encoding.ASCII.GetBytes(lgRequest), 0, lgRequest.Length);
        }
        WebResponse res = req.GetResponse();
        using(StreamReader reader = new StreamReader(res.GetResponseStream()))
        {
            string stringResponse = reader.ReadToEnd();
        }
        
    }
