    public class PropDouble
    {
        private double[] doubles;
        public double P0 { get { return doubles[0]; } set { doubles[0] = value; } }
        public double P1 { get { return doubles[1]; } set { doubles[1] = value; } }
        public PropDouble(double[] Doubles) { doubles = Doubles; }
    }
