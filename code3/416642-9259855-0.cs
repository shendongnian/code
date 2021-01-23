    var myobj =   JsonConvert.DeserializeObject<Class1[]>(json);
    public class Class1
    {
        public string token;
        public string type;
        public Update[] updates;
    }
    public class Update
    {
        public string __type;
    }
