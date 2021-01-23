    public class UnityFormatter : MediaTypeFormatter
    {
        private MediaTypeFormatter formatter;
        private IUnityContainer container;
        public UnityFormatter(MediaTypeFormatter formatter, IUnityContainer container)
        {
            this.formatter = formatter;
            this.container = container;
            foreach (var supportedMediaType in this.formatter.SupportedMediaTypes)
            {
                this.SupportedMediaTypes.Add(supportedMediaType);
            }
            foreach (var supportedEncoding in this.formatter.SupportedEncodings)
            {
                this.SupportedEncodings.Add(supportedEncoding);
            }
            foreach (var mediaTypeMapping in this.MediaTypeMappings)
            {
                this.MediaTypeMappings.Add(mediaTypeMapping);
            }
            this.RequiredMemberSelector = this.formatter.RequiredMemberSelector;
        }
        private Type ResolveType(Type type)
        {
            return this.container.Registrations.Where(n => n.RegisteredType == type).Select(n => n.MappedToType).FirstOrDefault() ?? type;
        }
        public override bool CanReadType(Type type)
        {
            return this.formatter.CanReadType(this.ResolveType(type));
        }
        public override bool CanWriteType(Type type)
        {
            return this.formatter.CanWriteType(this.ResolveType(type));
        }
        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            return this.formatter.GetPerRequestFormatterInstance(this.ResolveType(type), request, mediaType);
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return this.formatter.ReadFromStreamAsync(this.ResolveType(type), readStream, content, formatterLogger);
        }
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            this.formatter.SetDefaultContentHeaders(this.ResolveType(type), headers, mediaType);
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            return this.formatter.WriteToStreamAsync(this.ResolveType(type), value, writeStream, content, transportContext);
        }
    }
