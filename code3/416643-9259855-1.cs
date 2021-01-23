    var myobj =   JsonConvert.DeserializeObject<MyObject[]>(json);
    public class MyObject
    {
        public string token;
        public string type;
        public Update[] updates;
    }
    public class Update
    {
        public string __type;
    }
