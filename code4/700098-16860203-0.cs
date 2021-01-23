    var myObj =JsonConvert.DeserializeObject<RootObject>(json);
    public class Header
    {
        public int id { get; set; }
        public int code { get; set; }
        public int hits { get; set; }
    }
    public class Datalist
    {
        public string name { get; set; }
        public string city { get; set; }
        public int age { get; set; }
    }
    public class Body
    {
        public List<Datalist> datalist { get; set; }
    }
    public class RootObject
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }
