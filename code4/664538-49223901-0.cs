    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Test1), "Something1")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Test2), "Something2")]
    public interface ITestInterface
    {
        string Guid { get; set; }
    }
    
    public class Test1 : ITestInterface
    {
        public string Guid { get; set; }
        public string Something1 { get; set; }
    }
    
    public class Test2 : ITestInterface
    {
        public string Guid { get; set; }
        public string Something2 { get; set; }
    }
