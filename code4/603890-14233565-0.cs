    public abstract class XmlControl
    {
        [DefaultValue(0)]
        public int Width { get; set; }
    
        [DefaultValue(0)]
        public int Height { get; set; }
    
        public abstract Type ControlType();
