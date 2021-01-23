    public class Pump
    {
        public double Speed { get; set; }
        public double Size { get; set; }
        public void GetCFM() { return Speed * Size; }
    }
