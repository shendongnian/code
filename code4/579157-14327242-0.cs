    public class CouchbaseClientExtended : CouchbaseClient
    {
        private string _bucket;
        private bool _isDevMode;
        private CouchbaseCluster _cluster;
        public CouchbaseClientExtended()
        {
            LoadBaseConfig("couchbase");
        }
        public CouchbaseClientExtended(CouchbaseClientConfiguration config) : base(config)
        {
            LoadBaseConfig(config);
        }
        public CouchbaseClientExtended(string sectionName) : base(sectionName)
        {
            LoadBaseConfig(sectionName);
        }
        public CouchbaseClientExtended(ICouchbaseServerPool pool, CouchbaseClientConfiguration config) : base(pool, config)
        {
            LoadBaseConfig(config);
        }
        public CouchbaseClientExtended(string bucketName, string bucketPassword) : base(bucketName, bucketPassword)
        {
            var config = new CouchbaseClientConfiguration // I'm not sure about this one
            {
                Bucket = bucketName,
                BucketPassword = bucketPassword
            };
            LoadBaseConfig(config);
            _bucket = bucketName;
        }
        public CouchbaseClientExtended(CouchbaseClientConfiguration config, string bucketName, string bucketPassword) : base(config, bucketName, bucketPassword)
        {
            LoadBaseConfig(config);
            _bucket = bucketName;
        }
        public CouchbaseClientExtended(string sectionName, string bucketName, string bucketPassword)
            : base(sectionName, bucketName, bucketPassword)
        {
            LoadBaseConfig(sectionName);
            _bucket = bucketName;
        }
        private void LoadBaseConfig(string sectionName)
        {
            var config = ConfigurationManager.GetSection(sectionName) as CouchbaseClientSection;
            if (config == null)
            {
                throw new NullReferenceException(
                    "Couchbase configuration cannot be null. Add it to App.Config file or pass a custom one via parameter.");
            }
            _bucket = config.Servers.Bucket;
            _isDevMode = config.DocumentNameTransformer.Type == typeof (DevelopmentModeNameTransformer);
            _cluster = new CouchbaseCluster(config);
        }
        private void LoadBaseConfig(CouchbaseClientConfiguration config)
        {
            _bucket = config.Bucket;
            _isDevMode = config.DesignDocumentNameTransformer is DevelopmentModeNameTransformer;
            _cluster = new CouchbaseCluster(config);
        }
        public bool StoreJson<T>(StoreMode storeMode, string key, T value) where T : class
        {
            return Store(storeMode, key, JsonConvert.SerializeObject(value));
        }
        public T GetJson<T>(string key) where T : class
        {
            T obj = null;
            var json = Get<string>(key);
            if (json != null)
            {
                obj = JsonConvert.DeserializeObject<T>(json);
            }
            return obj;
        }
        public bool ViewExist(string designName, string viewName)
        {
            try
            {
                var doc = _cluster.RetrieveDesignDocument(_bucket, designName);
                if (string.IsNullOrEmpty(doc) ||
                    !doc.Contains(string.Format("\"{0}\"", viewName), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (_isDevMode)
                    {
                        var devDoc = _cluster.RetrieveDesignDocument(_bucket, "dev_" + designName);
                        return !string.IsNullOrEmpty(devDoc) &&
                            devDoc.Contains(string.Format("\"{0}\"", viewName),
                                StringComparison.InvariantCultureIgnoreCase);
                    }
                    return false;
                }
                return true;
            }
            catch (WebException wex)
            {
                if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound) // If the design document is not found, it will return Error 404
                {
                    return false;
                }
                throw;
            }
        }
    }
