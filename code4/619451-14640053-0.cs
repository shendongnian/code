    public class MyClass {
        public string id { get; set; }
        public string content { get; set; }
        public string ups { get; set; }
        public string downs { get; set; }
    }
    MyClass[] result = JsonConvert.DeserializeObject<MyClass[]>(download);
