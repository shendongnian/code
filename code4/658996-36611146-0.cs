    public class RetryMessageHandler : DelegatingHandler
    {
    	readonly int retryCount;
    	
    	public RetryMessageHandler(int retryCount)
    		: this(new HttpClientHandler(), retryCount)
    	{
    	}
    
    	public RetryMessageHandler(HttpMessageHandler innerHandler, int retryCount)
    		: base(innerHandler)
    	{
    		this.retryCount = retryCount;
    	}
    	
        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    	{
    		HttpResponseMessage response = null;
    	
    		for (int i = 0; i<=retryCount; i++)
    		{
    			response = await base.SendAsync(request, cancellationToken);
    				
    			if (response.IsSuccessStatusCode)
    			{
    				return response;
    			}
    		}
    		
    		return response;
    	}
    }
