    public  Task<IRestResponse> ExecuteAsync<T>(RestRequest request, RestClient client)
    {
      EventWaitHandle executedCallBack = new AutoResetEvent(false);
      TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
        
    IRestResponse res = new RestResponse();   
        try
        {
          var asyncHandle = client.ExecuteAsync<RestResponse>(request, response =>
            {
              res = response;
              tcs.TrySetResult(res);
              executedCallBack.Set();
            });
    
          
        }
        catch (Exception ex)
        {
          tcs.TrySetException(ex);
        }
    
        return tcs.Task;
    }
