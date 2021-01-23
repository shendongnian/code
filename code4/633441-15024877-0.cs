    public class EbayItem
        {
    
            public EbayItem()
            {
    
            }
    
            public EbayItem(string sku, int id, string product, int ebayqty, int stockqty)
            {
                SKU = sku;
                ID = id;
                ProductName = product;
                ebayQty = ebayqty;
                stockQty = stockqty;
    
            }
            public string SKU { get; set; }
            public int ID { get; set; }
            public string ProductName { get; set; }
            public int ebayQty { get; set; }
            public int stockQty { get; set; }
            public int difference
            {
    
                get { return stockQty - ebayQty; }
                set { difference =  value; }
            }
    
        }
