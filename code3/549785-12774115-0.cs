    public class SolrProduct
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [SolrField("manu")]
        public string Manufacturer { get; set; }
        [SolrField("cat")] // cat is a multiValued field
        public ICollection<string> Categories { get; set; }
        [SolrField("price")]
        public decimal Price { get; set; }
        [SolrField("inStock")]
        public bool InStock { get; set; }
        [SolrField("loca_zip")]
        public int Zip { set; get; }
        [SolrField("loca_country")]
        public string Country { get; set; }
    }
