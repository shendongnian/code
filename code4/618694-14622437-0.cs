    private const string Authorization = "Authorization";
    public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			object httpRequestMessageObject;
			if (request.Properties.TryGetValue(
				HttpRequestMessageProperty.Name, out httpRequestMessageObject))
			{
				var httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
				if (string.IsNullOrWhiteSpace(httpRequestMessage.Headers[Authorization]))
				{
					httpRequestMessage.Headers[Authorization] = "Basic Y19udGk6Q29udGlfQjNTVA==";
				}
			}
			else
			{
				var httpRequestMessage = new HttpRequestMessageProperty();
				httpRequestMessage.Headers.Add(Authorization, "Basic Y19udGk6Q29udGlfQjNTVA==");
				request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
			}
			return null;
		}
