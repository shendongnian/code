    public class WebServiceClient<T> : IDisposable
    {
        private readonly T _channel;
        private readonly IClientChannel _clientChannel;
        public WebServiceClient(string url)
            : this(url, null)
        {
        }
        /// <summary>
        /// Use action to change some of the connection properties before creating the channel
        /// </summary>
        public WebServiceClient(string url,
             Action<CustomBinding, HttpTransportBindingElement, EndpointAddress, ChannelFactory> init)
        {
            var binding = new CustomBinding();
            binding.Elements.Add(
                new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8));
            var transport = url.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)
                                ? new HttpsTransportBindingElement()
                                : new HttpTransportBindingElement();
            transport.AuthenticationScheme = System.Net.AuthenticationSchemes.Ntlm;
            binding.Elements.Add(transport);
            
            var address = new EndpointAddress(url);
            
            var factory = new ChannelFactory<T>(binding, address);
            factory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            
            if (init != null)
            {
                init(binding, transport, address, factory);
            }
            
            this._clientChannel = (IClientChannel)factory.CreateChannel();
            this._channel = (T)this._clientChannel;
        }
        /// <summary>
        /// Use this property to call service methods
        /// </summary>
        public T Channel
        {
            get { return this._channel; }
        }
        /// <summary>
        /// Use this porperty when working with
        /// Session or Cookies
        /// </summary>
        public IClientChannel ClientChannel
        {
            get { return this._clientChannel; }
        }
        public void Dispose()
        {
            this._clientChannel.Dispose();
        }
    }
