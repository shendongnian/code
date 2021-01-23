        class MyWebClient : WebClient
        {
            Uri _responseUri;
            public Uri ResponseUri
            {
                get { return _responseUri; }
            }
            protected override HttpWebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                _responseUri = response.ResponseUri;
                return (HttpWebResponse)response;
            }
        }
