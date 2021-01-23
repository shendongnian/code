    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
        {
    
            private string _callbackQueryParamter;
            private HttpRequestMessage HttpRequest;
    
            public JsonpMediaTypeFormatter()
            {
                SupportedMediaTypes.Add(DefaultMediaType);
                SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
    
                MediaTypeMappings.Add(new UriPathExtensionMapping("jsonp", DefaultMediaType));
            }
    
    
            public string CallbackQueryParameter
            {
                get { return _callbackQueryParamter ?? "callback"; }
                set { _callbackQueryParamter = value; }
            }
    
            public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type,
                                                HttpRequestMessage request,  MediaTypeHeaderValue mediaType)
            {
                HttpRequest = request;
                return base.GetPerRequestFormatterInstance(type, request, mediaType);
            }
           
            public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
            {
                string callback;
      
                if (IsJsonpRequest(out callback))
                {
                    return Task.Factory.StartNew(() =>
                    {
                        var writer = new StreamWriter(writeStream);
                        writer.Write(callback + "(");
                        writer.Flush();
                        base.WriteToStreamAsync(type, value, writeStream, content, transportContext).Wait();
                        writer.Write(")");
                        writer.Flush();
                    });
                }
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
    
            private bool IsJsonpRequest(out string callback)
            {
                var query = HttpUtility.ParseQueryString(HttpRequest.RequestUri.Query);
                callback = query[CallbackQueryParameter];
    
                return !string.IsNullOrEmpty(callback);
            }
        }
 
