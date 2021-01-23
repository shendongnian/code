    private static System.ServiceModel.Channels.Binding GetBinding(System.ServiceModel.Channels.Binding bIn)
        {
            var bOut = new CustomBinding(bIn);
            var transportElement = bOut.Elements
                  .Find<HttpsRelayTransportBindingElement>();
            transportElement.KeepAliveEnabled = false;
            return bOut;
        }
