    [CacheWebApi(Duration = 20)]
            public IEnumerable<string> Get()
            {
                return new string[] { DateTime.Now.ToLongTimeString(), DateTime.UtcNow.ToLongTimeString() };
            }
