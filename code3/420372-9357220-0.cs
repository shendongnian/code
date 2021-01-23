        [ThreadStatic]
        private static MyServ.MyService _client;
        public MyServ.MyService Client
        {
            get
            {
                if (_client == null
                    || (_client.State != CommunicationState.Opened
                            && _client.State != CommunicationState.Opening))
                    IntializeClient();
        
                return _client;
            }
        }
        private void IntializeClient()
        {
            if (_client != null)
            {
                if (_client.State == CommunicationState.Faulted)
                {
                    _client.Abort();
                }
                else
                {
                    _client.Close();    
                }
            }
            string url = //get url;
            var binding = new WSHttpBinding();
            var address = new EndpointAddress(url);
            _client = new MyServ.MyService(binding, address);            
        }
}
