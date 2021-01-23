    public class FieldAliases
    {
        public string STATE_NAME { get; set; }
    }
    
    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string alias { get; set; }
        public int length { get; set; }
    }
    
    public class Attributes
    {
        public string STATE_NAME { get; set; }
    }
    
    public class Feature
    {
        public Attributes attributes { get; set; }
    }
    
    public class RootObject
    {
        public string displayFieldName { get; set; }
        public FieldAliases fieldAliases { get; set; }
        public List<Field> fields { get; set; }
        public List<Feature> features { get; set; }
    }
