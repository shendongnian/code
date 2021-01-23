        public HTTPRequestFactory(IWebRequestCreate create)
        {
            _IWebRequestCreate = create;
        }
        public HTTPRequestFactory()
        {
            //Do nothing this is the real constructor, above is just for testing.
        }
        public WebRequest Create(String uri)
        {
            Uri _uri = new Uri("http://"+this.address+uri);
            request =  (HttpWebRequest)this.Create(_uri);
            return request;
        }
    
        public WebRequest  Create(Uri uri)
            if (null == _IWebRequestCreate)
            {
                //use the real one
                request = WebRequest.Create(uri);
            }
            else
            {
                //testing so use test one
                request = _IWebRequestCreate.Create(uri);
            }
            return request;
        }
