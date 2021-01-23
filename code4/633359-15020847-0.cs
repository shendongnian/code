    public class Query
    {
        public int QueryId { get; set; }
        public string Name { get; set; }
        public string Sql { get; set; }
        public Parameter[] Parameters { get; set; }
    }
    
    public class Parameter
    {
        public string Name { get; set; }
        public int DataType { get; set; }
        public string Value { get; set; }
        public bool IsArray { get; set; }
    }
