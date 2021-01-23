    public class Phase
    {
        public Int16 Trafo = 50;
        public KorrekturWerte Spannung = new KorrekturWerte() { Offset = 0, Steigung = 1 };
        public KorrekturWerte Strom = new KorrekturWerte() { Offset = 0, Steigung = 1 };
        private List<double> m_Min = new List<double>();
        private List<double> m_Max = new List<double>();
        public List<double> Min { get { return m_Min; } }
        public List<double> Max { get { return m_Max; } }
        //public double[] Default;
    }
