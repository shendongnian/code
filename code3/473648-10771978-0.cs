    public class SampleInformation
    {
        public string Nutrient { get; set; }
        public decimal NutrientTotal { get; set; }
        public int NoSamples { get; set; }
        public decimal Average { get; set; }
        public decimal StandardDeviation { get; set; }
        public decimal CoVariance { get; set; }
        public decimal PSD { get { return Average + StandardDeviation; } private set { } }
        public decimal NSD { get{ return Average-StandardDeviation;} private set{} }
    }
