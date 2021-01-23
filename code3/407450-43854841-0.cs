    public class Field
    {
        public string Label { get; set; }
    }
    public class Field<T> : Field
    {
        public T Value { get; set; }
    }
    public class Document
    {
        public string Content { get; set; }
    }
