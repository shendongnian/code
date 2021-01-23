    public class Report //my public class
    {
        // Only showing two properties here; do the rest in the same manner
        public double[] KwotaZ { get; set; }
        public double[] KwotaNa = { get; set; }
        public Report()
        {
            this.KwotaZ = new double[10];
            this.KwotaNa = new double[10];
        }
    }
