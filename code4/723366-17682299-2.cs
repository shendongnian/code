    [Description("Product Page")]
    class ProductPageResources
    {
        [Description("Page Title")]
        [DefaultValue("Product Details: {0}")
        public string PageTitle { get; set; }
    
        [Description("Product Name (label)")]
        [DefaultValue("Name:")]
        public string ProductNameLabel { get; set; }
    }
