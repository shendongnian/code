    public class MyData
    {
        public MyData() { }
        public MyData(string[] values)
        {
            Time = new DateTime(long.Parse(values[0]));
            HlState = int.Parse(values[1]);
            HLX = double.Parse(values[2]);
            HLY = double.Parse(values[3]);
            HLZ = double.Parse(values[4]);
        }
        public DateTime Time { get; set; }
        public int HLState { get; set; }
        public double HLX { get; set; }
        public double HLY { get; set; }
        public double HLZ { get; set; }
    }
