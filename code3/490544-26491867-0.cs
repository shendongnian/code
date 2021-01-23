    var response = "Hello";            
    Message msg = Message.CreateMessage(MessageVersion.Soap11, "*",response, new DataContractSerializer(response.GetType()));
    msg.Headers.Clear();
    var sb = new StringBuilder();
    var xmlWriter = new XmlTextWriter(new StringWriter(sb));
    msg.WriteBody(xmlWriter);
