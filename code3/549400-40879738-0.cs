    [TypeConverter(typeof(PropertySorter))]
    public class ColorProperty
    {
        [PropertyOrder(1)]
        public int R { get; set; }
        [PropertyOrder(2)]
        public int G { get; set; }
        [PropertyOrder(3)]
        public int B { get; set; }
    }
