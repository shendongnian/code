    public class M
    {
        public double[][] Matrix { get; private set; }
        public M()
        {
            Matrix = new double[2][]{new double[2], new double[2]};
        }
    }
    M n = new M();
    n.Matrix[0][0] = 1.0;
