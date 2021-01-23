    List<double[]> ld = new List<double[]>();
    List<PropDouble> lpd = new List<PropDouble>();
    foreach (double[] da in ld) { lpd.Add(new PropDouble(da)); }
    
    public class PropDouble
    {
        public double P1 { get; set; }
        public double P2 { get; set; }
        public PropDouble(double[] doubles) { P1 = doubles[0]; P2 = doubles[1]; }
    }
