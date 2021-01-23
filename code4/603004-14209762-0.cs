    public class MyViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<PartnerPricesViewModel> PartnerProductPrices { get; set; }
    }
    public class PartnerPricesViewModel
    {
        public string PartnerName { get; set; }
        public IEnumerable<Price> Prices { get; set; }
    }
