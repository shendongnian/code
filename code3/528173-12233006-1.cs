    public interface IYourWebService
    {
        XmlResponseObject GetData(int dataId);
    }
    
    public class YourWebService : IYourWebService
    {
        public XmlResponseObject GetData(int dataId)      
        {
            XmlResponseObject xmlResponseObject = null;
            var url = "http://SomeSite.com/Service/GetData/" + dataId;
            try
            {
             var request = WebRequest.Create(url) as HttpWebRequest;
             if (request != null)
             {
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 1.1.4322; InfoPath.2; .NET4.0C; .NET4.0E)";
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                request.CookieContainer = new CookieContainer();
                var response = request.GetResponse() as HttpWebResponse;
                if (request.HaveResponse && response != null)
                {
                    var streamReader = new StreamReader(response.GetResponseStream());
                    var xmlSerializer = new XmlSerializer(typeof(XmlResponseObject));
                    xmlResponseObject = (XmlResponseObject)xmlSerializer.Deserialize(streamReader);
                }
             }
            }
            catch (Exception ex)
            {
            string debugInfo = "\nURL: " + url;
            Console.Write(ex.Message + " " + debugInfo + " " + ex.StackTrace);
            }
        return xmlResponseObject;
        }
    }
