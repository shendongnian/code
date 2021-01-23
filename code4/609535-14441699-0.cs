    using System.ServiceModel.Channels;
    public Result CallTestDrive(Request request)
    {
        BindingElementCollection elements
            = base.Endpoint.Binding.CreateBindingElements();
        elements.Find<MessageEncodingBindingElement>().MessageVersion
            = MessageVersion.Soap12WSAddressingAugust2004;
        base.Endpoint.Binding = new CustomBinding(elements);
        return base.Channel.CallTestDrive(request);
    }
