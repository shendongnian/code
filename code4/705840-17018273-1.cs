    public class RawWcfMessage : IRequiresSoapMessage {
    	public Message Message { get; set; }
    }
    public object Post(RawWcfMessage request) { 
    	request.Message... //Raw WCF SOAP Message
    }
