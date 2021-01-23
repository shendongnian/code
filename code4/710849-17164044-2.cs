    using Microsoft.Web.Services2.Security.Tokens;
    using Microsoft.Web.Services2.Security.Utility;
    UsernameToken token = new UsernameToken(username, password, passwordOption.SendHashed);          
      
    Microsoft.Web.Services2.Security.Utility.Timestamp ts = new Timestamp();
    XmlDocument doc = new XmlDocument();
   
    XmlElement token = token.GetXml(doc);
    XmlElement timestamp = ts.GetXml(doc);
    string stoken = token.InnerXml;
    string stimestamp = ts.InnerXml;
