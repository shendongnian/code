    [XmlType("NewsObject")]
    public class News : BaseContent
    {
        // Some more auto properties
        public int B { get; set; }
    }
    [XmlType("EventObject")]
    public class Event : BaseContent
    {
        // Some more auto properites
        public int C { get; set; }
    }
    ...
    public class GenericResponse<T>
    {
        [XmlArray("Content")]
        public List<T> ContentItems { get; set; }
    }
