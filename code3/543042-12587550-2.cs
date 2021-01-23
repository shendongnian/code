    public static class HttpContextFactory
    {
        [ThreadStatic]
        private static HttpContextBase _mockHttpContext;
            public static void SetHttpContext(HttpContextBase httpContextBase)
        {
            _mockHttpContext = httpContextBase;
        }
    
        public static HttpContextBase GetHttpContext()
        {
            if (_mockHttpContext != null)
            {
                return _mockHttpContext;
            }
    
            if (HttpContext.Current != null)
            {
                return new HttpContextWrapper(HttpContext.Current);
            }
            return null;
        }
    }
