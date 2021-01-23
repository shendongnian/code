    public XDocument SendSMS()
    {
        XML = "<message id=\"" + lMessageID + "\"><partnerpassword>" + PartnerPassword + "</partnerpassword><content>" + sMessage + "</content></message>";
        URL = "http://sloocetech.net:****/spi-war/spi/" + PartnerID + "/" + sRecipient + "/" + Keyword + "/messages/mt";
        //check if the request object exists
        if (!Requests.Keys.Contains(sRecipient))
            Requests.Add((HttpWebRequest)WebRequest.Create(URL));
        //get the existing request from the dictionary
        Requests = Requests[sRecipient];
        //configure the request
        Request.Proxy = null;
        RequestBytes = System.Text.Encoding.ASCII.GetBytes(XML);
        Request.Method = "POST";
        Request.ContentType = "text/xml;charset=utf-8";
        Request.ContentLength = RequestBytes.Length;
        RequestStream = Request.
        RequestStream.Write(RequestBytes, 0, RequestBytes.Length);
        RequestStream.Close();
        using (System.IO.Stream RequestStream = Request.GetRequestStream())
        {
            using (WebResponse response = Request.GetResponse())
            {
                using (oReader = new StreamReader(Resp.GetResponseStream(), System.Text.Encoding.Default))
                {
                    string backstr = oReader.ReadToEnd();
                    Doc = XDocument.Parse(backstr);
                }
            }
        }
        return Doc;
    }
