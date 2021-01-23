    List<double[]> ld = new List<double[]>();
    List<PropDouble> lpd = new List<PropDouble>();
    foreach (double[] da in ld) { lpd.Add(new PropDouble(da)); }
    
    public class PropDouble
    {
        public double P0 { get; set; }
        public double P1 { get; set; }
        public PropDouble(double[] doubles) { P0 = doubles[0]; P1 = doubles[1]; }
    }
