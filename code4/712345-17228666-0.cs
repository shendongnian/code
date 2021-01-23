    public class Test
    {
        public Test(string name, string attribute1, string attribute2)
        {
            Name = name;
            Attributes = new Attribute(attribute1, attribute2);
        }
        public string Name { get; set; }
        public Attribute Attributes { get; set; }
    }
    public class Attribute
    {
        public Attribute(string attribute1, string attribute2)
        {
            Attribute1 = attribute1;
            Attribute2 = attribute2;
        }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
    }
