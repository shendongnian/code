    public class JsonNetFormatter : MediaTypeFormatter
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private string _callbackQueryParameter;
        public JsonNetFormatter(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings();
            // Fill out the mediatype and encoding we support
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedEncodings.Add(new UTF8Encoding(false, true));
            //we also support jsonp.
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
        }
        private Encoding Encoding
        {
            get { return SupportedEncodings[0]; }
        }
        public string CallbackQueryParameter
        {
            get { return _callbackQueryParameter ?? "callback"; }
            set { _callbackQueryParameter = value; }
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }
        public override bool CanWriteType(Type type)
        {
            return true;
        }
        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type,
                                                HttpRequestMessage request,
                                                MediaTypeHeaderValue mediaType)
        {
            var formatter = new JsonNetFormatter(_jsonSerializerSettings)
            {
                JsonpCallbackFunction = GetJsonCallbackFunction(request)
            };
            return formatter;
        }
        private string GetJsonCallbackFunction(HttpRequestMessage request)
        {
            if (request.Method != HttpMethod.Get)
                return null;
            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);
            var queryVal = query[CallbackQueryParameter];
            if (string.IsNullOrEmpty(queryVal))
                return null;
            return queryVal;
        }
        private string JsonpCallbackFunction { get; set; }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            // Create a serializer
            JsonSerializer serializer = JsonSerializer.Create(_jsonSerializerSettings);
            // Create task reading the content
            return Task.Factory.StartNew(() =>
            {
                using (var streamReader = new StreamReader(readStream, SupportedEncodings[0]))
                {
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        return serializer.Deserialize(jsonTextReader, type);
                    }
                }
            });
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var isJsonp = JsonpCallbackFunction != null;
            // Create a serializer
            JsonSerializer serializer = JsonSerializer.Create(_jsonSerializerSettings);
            // Create task writing the serialized content
            return Task.Factory.StartNew(() =>
            {
                using (var jsonTextWriter = new JsonTextWriter(new StreamWriter(writeStream, Encoding)) { CloseOutput = false })
                {
                    if (isJsonp)
                    {
                        jsonTextWriter.WriteRaw(JsonpCallbackFunction + "(");
                        jsonTextWriter.Flush();
                    }
                    serializer.Serialize(jsonTextWriter, value);
                    jsonTextWriter.Flush();
                    if (isJsonp)
                    {
                        jsonTextWriter.WriteRaw(")");
                        jsonTextWriter.Flush();
                    }
                }
            });
        }
    }
