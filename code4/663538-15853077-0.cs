    public class Json1
    {
        public Json2 response { get; set; }
    }
    public class Json2
    {
        public int success { get; set; }
        public int current_time { get; set; }
        public IDictionary<int, Json4> players { get; set; }
    }
    public class Json4
    {
        public long steamid { get; set; }
        public int success { get; set; }
        public double backpack_value { get; set; }
        public string name { get; set; }
    }
