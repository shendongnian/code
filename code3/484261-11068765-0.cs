    public class AuditLog<T>
    {
        public int UserID   { get; set; }
        public string LastSaved   { get; set;}
        [XmlArrayItem("Entry")]
        public List<AuditRecord<T>> Records;
    }
    public enum Flavor
    {
        Edit,
        Delete
    }
    public class AuditRecord<T>
    {
        public AuditRecord() { Stamp = DateTime.Now; }
        [XmlAttribute("action")]
        public Flavor Action  { get; set;}
        [XmlAttribute("stamp")]
        public DateTime Stamp   { get; set;}
        public T Before;
        public T After; // maybe null
    }
