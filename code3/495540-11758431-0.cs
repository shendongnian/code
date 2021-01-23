    public class UrlResourceLoader : ResourceLoader
    {
        protected ArrayList paths;
        protected Hashtable templatePaths;
        
        public UrlResourceLoader()
        {
            templatePaths = new Hashtable();
        }
        public override void Init(ExtendedProperties configuration)
        {
            paths = configuration.GetVector("path");
        }
        public override Stream GetResourceStream(string templateName)
        {
            lock (this)
            {
                int size = paths.Count;
                if (string.IsNullOrEmpty(templateName))
                {
                    throw;
                }
                for (int i = 0; i < size; i++)
                {
                    var path = (string) paths[i];
                    var uri = new Uri(path + templateName);
                    Stream inputStream = FindTemplate(uri);
                    if (inputStream != null)
                    {
                        SupportClass.PutElement(templatePaths, templateName, path);
                        return inputStream;
                    }
                }
                throw;
            }
        }
        private Stream FindTemplate(Uri requestUri)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.Method = "GET";
                var response = (HttpWebResponse) request.GetResponse();
                if (HttpStatusCode.OK != response.StatusCode)
                {
					throw;
                }
                return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
		
        public override bool IsSourceModified(Resource resource)
        {
            var path = (string)templatePaths[resource.Name];
            var uri = new Uri(path + resource.Name);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                return response.LastModified.Ticks != resource.LastModified;
            }
        }
        public override long GetLastModified(Resource resource)
        {
            var path = (string)templatePaths[resource.Name];
            var uri = new Uri(path + resource.Name);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                return response.LastModified.Ticks;
            }
        }
	}
