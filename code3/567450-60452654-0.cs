public partial class WsdlClient 
    {
        public WsdlClient (string endpointUrl, TimeSpan timeout, string username, string password) :
            base(WsdlClient.GetBindingForEndpoint(timeout), WsdlClient.GetEndpointAddress(endpointUrl))
        {
            this.ChannelFactory.Credentials.UserName.UserName = username;
            this.ChannelFactory.Credentials.UserName.Password = password;           
        }
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(TimeSpan timeout)
        {
            var httpsBinding = new BasicHttpsBinding();
            httpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            httpsBinding.Security.Mode = BasicHttpsSecurityMode.Transport;
            var integerMaxValue = int.MaxValue;
            httpsBinding.MaxBufferSize = integerMaxValue;
            httpsBinding.MaxReceivedMessageSize = integerMaxValue;
            httpsBinding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            httpsBinding.AllowCookies = true;
            httpsBinding.ReceiveTimeout = timeout;
            httpsBinding.SendTimeout = timeout;
            httpsBinding.OpenTimeout = timeout;
            httpsBinding.CloseTimeout = timeout;
            return httpsBinding;
        }
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(string endpointUrl)
        {
            if (!endpointUrl.StartsWith("https://"))
            {
                throw new UriFormatException("The endpoint URL must start with https://.");
            }
            return new System.ServiceModel.EndpointAddress(endpointUrl);
        }
    }
---------------------------
WsdlClient MyWsdlClient =>
            new WsdlClient (ConfigurationManager.AppSettings["endpointUrl"]
                , new TimeSpan(0, 0, 1, 0),
                "blabla",
                "blabla");
