	public class ServiceRouter : IMyServices
    {
        private readonly string ServiceURI;
        /// <summary>
        /// Routes data requests over the LAN if the client is connected locally or over a WCF service if the client is remote. Use this constructor to route data requests over the LAN.
        /// </summary>
        /// http://msdn.microsoft.com/en-us/library/ms735103.aspx
        /// 
        public ServiceRouter()
        {
            ServiceURI = null;
        }
        /// <summary>
        /// Routes data requests over the LAN if the client is connected locally or over a WCF service if the client is remote.
        /// </summary>
        /// <param name="serviceURI">Fully qualified URI of a WCF server if the user is remote.  Pass null if the user authenticated on the LAN (including using VPN)</param>
        /// http://msdn.microsoft.com/en-us/library/ms735103.aspx
        /// 
        public ServiceRouter(string serviceURI)
        {
            ServiceURI = serviceURI;
        }
        public IEnumerable<Allocation> GetAllocations()
        {
            IMyServices client = GetClient();
            var result = client.GetAllocations().ToList();
            CloseClient(client);
            return result;
        }
		
		  #region WCFClient
        private IMyServices GetClient()
        {
            IMyServices _client;
            
            if (string.IsNullOrEmpty(ServiceURI))
                _client = new MYServices();
            else
            {
                _client = ChannelFactory<IMyServices>.CreateChannel(new BasicHttpBinding(), new EndpointAddress(ServiceURI));
                ((ICommunicationObject)_client).Open();
            }
            return _client;
        }
        private void CloseClient(IMyServices client)
        {
            ICommunicationObject wcfClient = client as ICommunicationObject;
            if (wcfClient != null)
            {
                if (wcfClient.State == CommunicationState.Faulted)
                    wcfClient.Abort();
                else
                    wcfClient.Close();
            }
            else
                ((IDisposable)client).Dispose();
        }
        #endregion
    }
