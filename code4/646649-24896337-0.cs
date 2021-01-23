    public class CustomJsonSerializer : ISerializer
    {
        public CustomJsonSerializer()
        {
            ContentType = "application/json";
        }
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }
    }
