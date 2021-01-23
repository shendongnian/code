    // Notice that IDisposable is not implemented here!
    public interface HttpClientHandle
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Uri BaseAddress { get; set; }
        // ...
        // All the other methods from peeking at HttpClient
    }
    
    public class HttpClientHander : HttpClient, HttpClientHandle, IDisposable
    {
        public static ConditionalWeakTable<Uri, HttpClientHander> _httpClientsPool;
        static HttpClientHander()
        {
            _httpClientsPool = new ConditionalWeakTable<Uri, HttpClientHander>();
            SetupGlobalPoolFinalizer();
        }
        private DateTime _delayFinalization = DateTime.MinValue;
        private bool _isDisposed = false;
        public static HttpClientHandle GetHttpClientHandle(Uri baseUrl)
        {
            HttpClientHander httpClient = _httpClientsPool.GetOrCreateValue(baseUrl);
            httpClient._delayFinalization = DateTime.MinValue;
            httpClient.BaseAddress = baseUrl;
            return httpClient;
        }
        void IDisposable.Dispose()
        {
            _isDisposed = true;
            GC.SuppressFinalize(this);
            base.Dispose();
        }
        ~HttpClientHander()
        {
            if (_delayFinalization == DateTime.MinValue)
                _delayFinalization = DateTime.UtcNow;
            if (DateTime.UtcNow.Subtract(_delayFinalization) < base.Timeout)
                GC.ReRegisterForFinalize(this);
        }
        private static void SetupGlobalPoolFinalizer()
        {
            AppDomain.CurrentDomain.ProcessExit +=
                (sender, eventArgs) => { FinalizeGlobalPool(); };
        }
        private static void FinalizeGlobalPool()
        {
            foreach (var client in _httpClientsPool)
                client.Value.Dispose();
            _httpClientsPool.Clear();
        }
    }
