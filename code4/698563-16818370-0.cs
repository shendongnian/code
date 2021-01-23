    public class KaufViewModel
    {
        public double Price { get; set; }
        public string Value { get; set; }
        ...
    }
    public class BondViewModel
    {
        public KaufViewModel Kauf { get; set; }
    }
