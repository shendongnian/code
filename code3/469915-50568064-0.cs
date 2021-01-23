    public class JsonContent : HttpContent
       {
        private readonly MemoryStream _stream = new MemoryStream();
        ~JsonContent()
        {
            _stream.Dispose();
        }
        public JsonContent(object value)
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var contexStream = new MemoryStream())
            using (var jw = new JsonTextWriter(new StreamWriter(contexStream)) { Formatting = Formatting.Indented })
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(jw, value);
                jw.Flush();
                contexStream.Position = 0;
                contexStream.WriteTo(_stream);
            }
            _stream.Position = 0;
        }
        private JsonContent(string content)
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var contexStream = new MemoryStream())
            using (var sw = new StreamWriter(contexStream))
            {
                sw.Write(content);
                sw.Flush();
                contexStream.Position = 0;
                contexStream.WriteTo(_stream);
            }
            _stream.Position = 0;
        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return _stream.CopyToAsync(stream);
        }
        protected override bool TryComputeLength(out long length)
        {
            length = _stream.Length;
            return true;
        }
        public static HttpContent FromFile(string filepath)
        {
            var content = File.ReadAllText(filepath);
            return new JsonContent(content);
        }
        public string ToJsonString()
        {
            return Encoding.ASCII.GetString(_stream.GetBuffer(), 0, _stream.GetBuffer().Length).Trim();
        }
    }
