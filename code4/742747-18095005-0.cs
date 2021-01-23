    public class Pair<XType, YType>
    {
        public XType X { get; set; }
        public YType Y { get; set; }
    }
    public class ChartModel<XType, YType>
    {
        public List<Pair<XType, YType>> Data { get; set; }
    }
