    var entries = JsonConvert.DeserializeObject<Root>(json);
----
    public class Entry
    {
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
        public string video { get; set; }
    }
    public class Entries
    {
        public Entry Entry { get; set; }
    }
    public class Root
    {
        public Entries Entries { get; set; }
    }
