    public class MyData
    {
        public string LeaseName { get; set; }
        public int UltOil { get; set; }
        public int UltGas { get; set; }
        public static string GetHeaders()
        {
            return "LeaseName, UltOil, UltGas";
        }
        public override string ToString()
        {
            return string.Join(",", LeaseName, UltOil, UltGas);
        }
    }
