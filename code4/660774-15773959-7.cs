    public class DataLine
    {
        private const double _Scale = 4.0;
        public double Length { get; set; }
        public double DisplayLength { get { return Length * _Scale; } }
    }
