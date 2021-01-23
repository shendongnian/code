    [MediaType("application/json;q=0.3", "json")]
    [MediaType("text/html;q=0.3", "html")]
    public class NewtonsoftJsonCodec : IMediaTypeReader, IMediaTypeWriter
    {
        public object Configuration { get; set; }
        public object ReadFrom(IHttpEntity request, IType destinationType, string destinationName)
        {
            using (var streamReader = new StreamReader(request.Stream))
            {
                var ser = new JsonSerializer();
                
                return ser.Deserialize(streamReader, destinationType.StaticType);
            }
        }
        public void WriteTo(object entity, IHttpEntity response, string[] parameters)
        {
            if (entity == null)
                return;
            using (var textWriter = new StreamWriter(response.Stream))
            {
                var serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Include;
                serializer.Serialize(textWriter, entity);
            }
        }
    }
