    public class CustomSoapHttpClientProtocol : SoapHttpClientProtocol
    {
        public string SoapActionUrl { get; private set; }
        public CustomSoapHttpClientProtocol(string soapActionUrl)
        {
            this.SoapActionUrl = soapActionUrl;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            const string soapAction = "SOAPAction";
            if (request.Headers.Count > 0 && request.Headers.AllKeys.Contains(soapAction))
            {
                request.Headers[soapAction] = SoapActionUrl;
            }
            WebResponse response = base.GetWebResponse(request);
            return response;
        }
