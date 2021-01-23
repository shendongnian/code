    Api.Servicereference1.PortClient object = new Api.Servicereference1.PortClient();
    using ( OperationContextScope scope = new OperationContextScope(object.InnerChannel))
    {
         MessageHeader soapheader = MessageHEader.CreateHeader("name","ns",payload);
         OperationContext.Current.OutgoingMessageHeaders.Add(soapheader);
         object.testmethod();
    }
