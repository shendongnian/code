        protected static readonly Dictionary<string, string> ExtensionContentType;
        protected FileInfo fi;
        static StaticFileHandler()
        {
            ExtensionContentType = new Dictionary<string, string>       (StringComparer.InvariantCultureIgnoreCase) 
            {
                { ".text", "text/plain" },
                { ".js", "text/javascript" },
                { ".css", "text/css" },
                { ".html", "text/html" },
                { ".htm", "text/html" },
                { ".png", "image/png" },
                { ".ico", "image/x-icon" },
                { ".gif", "image/gif" },
                { ".bmp", "image/bmp" },
                { ".jpg", "image/jpeg" }
            };
        }
        
        public string BaseDirectory { protected set; get; }
        public string Prefix { protected set; get; }
        
        public StaticFileHandler(string baseDirectory, string prefix) 
        {            
            BaseDirectory = baseDirectory;
            Prefix = prefix;
        }
        private StaticFileHandler(FileInfo fi)
        {
            this.fi = fi;
        }
        public static StaticFileHandler Factory(string baseDirectory, string prefix, string pathInfo)
        {
            if (!pathInfo.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }
            
            var fn = baseDirectory + "/" + pathInfo.After(prefix.Length);
          
            var fi = new System.IO.FileInfo(fn);
            if (!fi.Exists)
            {
                return null;
            }
           return new StaticFileHandler(fi);
        }   
        public override void ProcessRequest(IHttpRequest httpReq, IHttpResponse httpRes, string operationName)
        {
            using (var source = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open))
            {
                var bytes = source.ReadAllBytes();
                httpRes.OutputStream.Write(bytes, 0, bytes.Length);
            }
            // timeStamp = fi.LastWriteTime;                        
            httpRes.AddHeader("Date", DateTime.Now.ToString("R"));
            httpRes.AddHeader("Content-Type", ExtensionContentType.Safeget(fi.Extension) ?? "text/plain");                       
        }
        public override object CreateRequest(IHttpRequest request, string operationName)
        {
            return null;
        }
        public override object GetResponse(IHttpRequest httpReq, IHttpResponse httpRes, object request)
        {
            return null;
        }
    }
