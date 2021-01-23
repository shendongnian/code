        class MyWebClient : WebClient
        {
            Uri _responseUri;
            public Uri ResponseUri
            {
                get { return _responseUri; }
            }
            public string GetFileName
            {
                get { return Path.GetFileName(_responseUri.AbsolutePath); }
            }
            protected override WebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                _responseUri = response.ResponseUri;
                return response;
            }
        }
