    public class HttpXmlClient : ClientBase<IHttpXmlClient>, IHttpXmlClient
    {
      public void Send(Stream data)
      {
        using (new OperationContextScope((IContextChannel) Channel))
        {
          var request = WebOperationContext.Current.OutgoingRequest;
          request.ContentType = "text/xml;charset=UTF-8";
          Channel.Send(data);
        }
      }
    }
