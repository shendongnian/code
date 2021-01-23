        public HTTPRequestFactory(IWebRequestCreate create)
        {
            _IWebRequestCreate = create;
        }
        public WebRequest Create(String uri)
        {
            Uri _uri = new Uri("http://"+this.address+uri);
            request =  (HttpWebRequest)this.Create(_uri);
            return request;
        }
    
        public WebRequest  Create(Uri uri)
        {
            request = (HttpWebRequest)_IWebRequestCreate.Create(uri);
            return request;
        }
