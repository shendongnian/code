    public class MyHttpProtocol : SoapHttpClientProtocol  
    {
        public override WebRequest GetWebRequest(Uri uri)
        {
            // Base request:
            WebRequest request = base.GetWebRequest(uri);
            // You code goes here...
            // Return...
            return request;
        }
    }
