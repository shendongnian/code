    public class Json1
    {
        public Json2 response { get; set; }
    }
    public class Json2
    {
        public int success { get; set; }
        public string current_time { get; set; }
        public IDictionary<int, IDictionary<int, IDictionary<int, Json5>>> prices { get; set; }
    }
    public class Json5
    {
        public Json6 current { get; set; }
    }
    public class Json6
    {
        public string currency { get; set; }
        public string value { get; set; }
        public string value_high { get; set; }
    }
