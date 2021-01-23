    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [ScriptIgnore]
        public DateTime Birthday { get; set; }
    }
