    public class NoCharsetJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public override void SetDefaultContentHeaders(Type type, System.Net.Http.Headers.HttpContentHeaders headers, System.Net.Http.Headers.MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType.CharSet = null;
        }
    }
