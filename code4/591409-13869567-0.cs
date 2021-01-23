    public static class RestClientExtensions
    	{
    		public static Task<IRestResponse> ExecuteTask (this IRestClient restClient, RestRequest restRequest)
    		{
    			var tcs = new TaskCompletionSource<IRestResponse> ();
    			restClient.ExecuteAsync (restRequest, (restResponse, asyncHandle) =>
    			{
    				if (restResponse.ResponseStatus == ResponseStatus.Error)
    					tcs.SetException (restResponse.ErrorException);
    				else
    					tcs.SetResult (restResponse);
    			});
    			return tcs.Task;
    		}
    	}
