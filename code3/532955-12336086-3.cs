    [JsonConverter(typeof(MyResponseConverter))]
    public class MyResponse
    {
        public ResponseBlog blog { get; set; }
        public Post[] posts { get; set; }
    }
