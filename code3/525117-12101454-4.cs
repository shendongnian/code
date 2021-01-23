    public class UnitConverter
        {
            double ratio;
            public string From { get; set; }
            public string To { get; set; }
            public UnitConverter(double unitratio) { ratio = unitratio; }
            public double Convert(double unit) { return unit * ratio; }
        }
