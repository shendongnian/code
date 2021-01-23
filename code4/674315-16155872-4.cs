    public class WcfChannelFactory<T> : ChannelFactory<T> where T : class
    {
        public WcfChannelFactory(Binding binding) : base(binding) {}
    
        public T CreateBaseChannel()
        {
            return base.CreateChannel(this.Endpoint.Address, null);
        }
    
        public override T CreateChannel(EndpointAddress address, Uri via)
        {
            // This is where the magic happens. We don't really return a channel here;
            // we return WcfClientProxy.GetTransparentProxy(). That class will now
            // have the chance to intercept calls to the service.
            this.Endpoint.Address = address;            
            var proxy = new WcfClientProxy<T>(this);
            return proxy.GetTransparentProxy() as T;
        }
    }
