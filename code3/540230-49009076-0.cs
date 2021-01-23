    public class TextMediaTypeFormatter : MediaTypeFormatter
    {
        public TextMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return ReadFromStreamAsync(type, readStream, content, formatterLogger, CancellationToken.None);
        }
        public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            using (var streamReader = new StreamReader(readStream))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }
        public override bool CanWriteType(Type type)
        {
            return false;
        }
    }
