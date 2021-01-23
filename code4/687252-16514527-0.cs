    public class ConcreteLayer: Layer
    {
        public Layer Parent { get; set; }
        public Dictionary<Int32, Layer> Children{ get; set; }
    }
    public class FinalLayer: Layer
    {
        public Layer Parent { get; set; }
        public String ResultTableName { get; set; }
    }
