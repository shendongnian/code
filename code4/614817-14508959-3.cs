    public partial class PayPalAPIInterfaceClient : System.ServiceModel.ClientBase<PayPalAPIInterfaceServiceService>
    {
        public PayPalAPIInterfaceClient(System.ServiceModel.Channels.Binding binding,
                                        System.ServiceModel.EndpointAddress remoteAddress) 
               : base(binding, remoteAddress) { }
    }
