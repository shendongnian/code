    public class CodeList
    {
        public string displayProperty1 {get; set;}
        public string displayProperty2 {get; set;}
    }
    
    public class CodeListC : CodeList
    {
        public string displayProperty3 {get; set;}
        // Other two properties will be inherited
    }
