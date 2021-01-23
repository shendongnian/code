    public class SoapHeaderBehaviour : BehaviorExtensionElement, IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState) { }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        { 
            var security = new Security();   // details irrelevant
            var messageHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", security, new ConcreteXmlObjectSerializer(typeof(Security)), true);
            request.Headers.Add(messageHeader);
            return null;
        }
        protected override object CreateBehavior() { return new SoapHeaderBehaviour(); }
        public override Type BehaviorType { get { return GetType(); } }
    }
