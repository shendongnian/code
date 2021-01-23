    public class MyDispatchMessageInspector : IDispatchMessageInspector
    {
	public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
	{
		HttpRequestMessageProperty httpRequestMessageProperty;
		object obj;
		if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out obj))
		{
			httpRequestMessageProperty = obj as HttpRequestMessageProperty;
			if (!string.IsNullOrEmpty(httpRequestMessageProperty.Headers[HttpRequestHeader.ContentEncoding]))
			{
				...
			}
		}
		return null;
	}
	...
    }
