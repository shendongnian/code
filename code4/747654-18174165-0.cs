    var jObj = JsonConvert.DeserializeObject <List<Compound>>(response);
---
    public class Compound
    {
        public string Name { get; set; }
        public List<Identifier> Identifiers { set; get; }
    }
    public class Identifier
    {
        public string Version { get; set; }
        public string Value { get; set; }
        public int IdentifierType { get; set; }
    }
