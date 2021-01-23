    using Remoting;
    
    namespace FileEventReaderService.Services.Remotable
    {
        class SingletonClient
        {
            private static SingletonClient _instance = new SingletonClient();
            private Client _client = null;
            
            public static SingletonClient GetSingletonClient()
            {
                return _instance;
            }
    
            public Client GetClient()
            {
                return _client;
            }
    
            public void SetClientConfiguration(string url)
            {
                _client=new Client(url);
            }
        }
    }
