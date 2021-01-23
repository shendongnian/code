    public static HttpResponseMessage PostAsyncSafe(this HttpClient client, string requestUri, string content)
    		{
    			var requestContent = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
    			return PerformActionSafe(() => (client.PostAsync(requestUri, requestContent)).Result);
    		}
    public static HttpResponseMessage PerformActionSafe(Func<HttpResponseMessage> action)
    		{
    			try
    			{
    				return action();
    			}
    			catch (AggregateException aex)
    			{
    				Exception firstException = null;
    				if (aex.InnerExceptions != null && aex.InnerExceptions.Any())
    				{
    					firstException = aex.InnerExceptions.First();
    
    					if (firstException.InnerException != null)
    						firstException = firstException.InnerException;
    				}
    
    				var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
    				{
    					Content =
    						new StringContent(firstException != null
    											? firstException.ToString()
    											: "Encountered an AggreggateException without any inner exceptions")
    				};
    
    				return response;
    			}
    		}
