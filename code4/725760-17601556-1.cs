    public class Foo
    {
        public int Id;
    	[JsonConverter(typeof(StringToObjectConverter))]
        public string RawData;
    }
