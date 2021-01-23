    string requestUrl = null;
    requestUrl = "https://apps.quickbooks.com/j/AppGateway";
    
    
    HttpWebRequest WebRequestObject = null;
    StreamReader sr = null;
    HttpWebResponse WebResponseObject = null;
    StreamWriter swr = null;
    
    
    try
    {
        WebRequestObject = (HttpWebRequest)WebRequest.Create(requestUrl);
        WebRequestObject.Method = "POST";
        WebRequestObject.ContentType = "application/x-qbxml";
        WebRequestObject.AllowAutoRedirect = false;
    
    string post = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
    <?qbxml version=""6.0""?>
    <QBXML>
    <SignonMsgsRq>
    <SignonDesktopRq>
    <ClientDateTime>%%CLIENT_DATE_TIME%%</ClientDateTime>
    <ApplicationLogin>APPLICATION_LOGIN</ApplicationLogin>
    <ConnectionTicket>CONNECTION_TICKET</ConnectionTicket>
    <Language>English</Language>
    <AppID>APP_ID</AppID>
    <AppVer>1</AppVer>
    </SignonDesktopRq>
    </SignonMsgsRq>
    <QBXMLMsgsRq onError=""continueOnError"">
    <CustomerQueryRq requestID=""2"" />
    </QBXMLMsgsRq>
    </QBXML>"; 
    
    post = post.Replace("%%CLIENT_DATE_TIME%%", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(post);
        post = xmlDoc.InnerXml;
        WebRequestObject.ContentLength = post.Length;
        swr = new StreamWriter(WebRequestObject.GetRequestStream());
        swr.Write(post);
        swr.Close();
        WebResponseObject = (HttpWebResponse)WebRequestObject.GetResponse();
        sr = new StreamReader(WebResponseObject.GetResponseStream());
        string Results = sr.ReadToEnd();
        }
    finally
        {
            try
            {
                sr.Close();
            }
            catch
            {
            }
    
    
        try
        {
            WebResponseObject.Close();
            WebRequestObject.Abort();
        }
        catch
        {
        }
