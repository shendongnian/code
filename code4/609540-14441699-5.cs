    using System.ServiceModel;
    using System.ServiceModel.Channels;
    public class CustomWsHttpBinding : WSHttpBinding
    {
        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection elements = base.CreateBindingElements();
            MessageEncodingBindingElement encodingElement
              = elements.Find<MessageEncodingBindingElement>();
            encodingElement.MessageVersion
              = MessageVersion.Soap12WSAddressingAugust2004;
            return elements;
        }
    }
