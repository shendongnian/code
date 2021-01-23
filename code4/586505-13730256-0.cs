    public class Foo
    {
        public string SaveCode { get; set; }
        public bool IsMainProject { get; set; }
        public List<DesignerItem> DesignerItems { get; set; }
    }
    
    public class DesignerItem
    {
        public string Quiddity { get; set; }
        public string Name { get; set; }
        public string LoopBodyInDesignerCanvas { get; set; }
    }
