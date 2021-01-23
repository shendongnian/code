    public class Column
    {
        private Source _Source = new Source();
        private Destination _Destination = new Destination();
    
        public Source Source { get { return _Source; } }
        public Destination Destination { get { return _Destination; } }
    }
    
    public class Source
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    
    public class Destination
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
