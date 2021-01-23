    public class MyHttpClient
    {
      private HttpClient _client = new HttpClient();
      private MyHttpClientSetup _setup;
      public MyHttpClient(MyHttpClientSetup setup)
      {
        this._setup = setup;
      }
      private void HttpLogin() 
      { 
        // .. custom login stuff that uses this._setup
      }     
      private void HttpLogout() 
      { 
        // .. custom logout stuff that uses this._setup
      }     
      public void Reset()
      {
        this._client = new HttpClient();
      }
      // Wrapped Properties from the private HttpClient (1 example)
      public Uri BaseAddress 
      { 
        get{ return this._client.BaseAddress;} 
        set{ this._client.BaseAddress = value;} 
      }
      // Wrapped HttpMethods (1 example)
      // Extremely poorly written, should be delegated properly
      // This is just a bad example not using Task properly
      public Task<HttpResponseMessage> DeleteAsync(string requestUri)
      {
        this.HttpLogin();
        Task<HttpResponseMessage> result = this._client.DeleteAsync(requestUri);
        this.HttpLogout();
        return result;
      }
      
      public class MyHttpClientSetup
      {
        // Properties required for setup;
      }
    }
