    public class MyDispatchMessageInspector : IDispatchMessageInspector
    {
        public class MyDispatchMessageInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
	        {
	            object obj;
                if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out obj))
	            {
		             var httpRequestMessageProperty = obj as HttpRequestMessageProperty;
		             
                     if (httpRequestMessageProperty != null 
                             && !string.IsNullOrEmpty(httpRequestMessageProperty.Headers[HttpRequestHeader.ContentEncoding]))
		             {
			            ...
		             }
	            }
	            return null;
         }
	     ...
    }
