        public Uri GetUri()
        {
            var location = _config.Get("http://iberia.com");
            Dictionary<string, string> values = GetDictionaryParameters();
            var uri = Microsoft.AspNet.WebUtilities.QueryHelpers.AddQueryString(location, values);
            return new Uri(uri);
        }
        private Dictionary<string,string> GetDictionaryParameters()
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "param1", "value1" },
                { "param2", "value2"},
                { "param3", "value3"}
            };
            return values;
        }
