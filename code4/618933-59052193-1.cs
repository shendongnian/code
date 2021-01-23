    var requestMessage = new HttpRequestMessage
    	{
            Method = HttpMethod.Post,
    		Content = new StringContent("...", Encoding.UTF8, "application/json"),
    		RequestUri = new Uri("..."),
    	};
    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", 
    	Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{user}:{password}")));
