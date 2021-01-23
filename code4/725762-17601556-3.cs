    public class Foo
    {
        public int Id;
    	[JsonConverter(typeof(RawJsonConverter))]
        public string RawData;
    }
