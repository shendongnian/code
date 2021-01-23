    // Notice that IDisposable is not implemented here!
    public interface HttpClientHandle
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Uri BaseAddress { get; set; }
        // ...
        // All the other methods from peeking at HttpClient
    }
    
    public class HttpClientHandler : HttpClient, HttpClientHandle
    {
        public static ConditionalWeakTable<Uri, HttpClientHandler> _httpClientsPool;
    
        public static HttpClientHandle GetHandle(Uri uri)
        {
                HttpClientHandler httpClient = _httpClientsPool.GetOrCreateValue(baseUrl);
                httpClient.BaseAddress = baseUrl;
    
                return httpClient;
        }
    
        static HttpClientHandler()
        {
            _httpClientsPool = new ConditionalWeakTable<Uri, HttpClientHandler>();
            AppDomain.CurrentDomain.ProcessExit +=
                (sender, eventArgs) =>
                {
                    foreach (var client in _httpClientsPool)
                    {
                        client.Value.Dispose();
                    }
                    _httpClientsPool.Clear();
                };
        }
    }
