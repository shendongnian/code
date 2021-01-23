    private HttpResponseMessage CreateResponseMessage(HttpWebResponse webResponse, HttpRequestMessage request)
    {
          HttpResponseMessage httpResponseMessage = new HttpResponseMessage(webResponse.StatusCode);
          httpResponseMessage.ReasonPhrase = webResponse.StatusDescription;
          httpResponseMessage.Version = webResponse.ProtocolVersion;
          httpResponseMessage.RequestMessage = request;
          httpResponseMessage.Content = (HttpContent) new StreamContent((Stream) new HttpClientHandler.WebExceptionWrapperStream(webResponse.GetResponseStream()));
          //this line doesnt exist, would be nice
          httpResponseMessage.IsFromCache = webResponse.IsFromCache;// <-- MISSING!
         ...
     }
