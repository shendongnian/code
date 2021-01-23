    UsernameToken token = new UsernameToken(username, password, PasswordOption.SendHashed);
                 
    Microsoft.Web.Services2.Security.Utility.Timestamp ts = new Timestamp();
    XmlDocument doc = new XmlDocument();
   
    XmlElement token = token.GetXml(doc);
    XmlElement timestamp = ts.GetXml(doc);
    string stoken = token.InnerXml;
    string stimestamp = ts.InnerXml;
