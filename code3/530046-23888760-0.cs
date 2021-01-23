    public partial class RestClient
    {
    	public Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request)
    	{
    		var tcs=new TaskCompletionSource<IRestResponse<T>>();
    
    		this.ExecuteAsync(request, response => 
    			{
    				tcs.SetResult(
   				        Deserialize<T>(request, response)
    				);
    			});
   
   		return tcs.Task;
    	}		
    }
