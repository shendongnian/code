      internal class HttpClientSingletonWrapper : HttpClient
    {
        private static readonly Lazy<HttpClientSingletonWrapper> Lazy= new Lazy<HttpClientSingletonWrapper>(()=>new HttpClientSingletonWrapper()); 
        public static HttpClientSingletonWrapper Instance {get { return Lazy.Value; }}
        private HttpClientSingletonWrapper()
        {
        }
    }
