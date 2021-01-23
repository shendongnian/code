    static class JsonRetriever
    {
        public async static Task<T> GetJsonFromUri<T>(string uriString)
        {
            var uri = new Uri(uriString);
            return await GetJsonFromUri<T>(uri);
        }
        public async static Task<T> GetJsonFromUri<T>(Uri uri)
        {
            var webRequest = System.Net.WebRequest.CreateHttp(uri);
            using (var webResponse = await Task<System.Net.WebResponse>.Factory.FromAsync(webRequest.BeginGetResponse, webRequest.EndGetResponse, TaskCreationOptions.None))
            {
                using (var stream = webResponse.GetResponseStream())
                {
                    return GetJson<T>(stream);
                }
            }
        }
        public static T GetJson<T>(System.IO.Stream stream)
        {
            using (var streamReader = new System.IO.StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var jsonSerializer = JsonSerializer.CreateDefault();
                    var instanceOfT = jsonSerializer.Deserialize<T>(jsonTextReader);
                    return instanceOfT;
                }
            }
        }
        public static T GetJson<T>(System.String json)
        {
            using (System.IO.TextReader textReader = new System.IO.StringReader(json))
            {
                var jsonSerializer = JsonSerializer.CreateDefault();
                var instanceOfT = (T)jsonSerializer.Deserialize(textReader, typeof(T));
                return instanceOfT;
            }
        }
    }
