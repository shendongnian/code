    public ActionResult Index()
    {
        List<Product> products = ...
        List<Partner> partners = ...
        List<Price> prices = ...
        var model = new MyViewModel
        {
            Products = products,
            PartnerProductPrices =
                from partner in partners
                select new PartnerPricesViewModel
                {
                    PartnerName = partner.Name,
                    Prices = 
                        from product in products
                        select prices.FirstOrDefault(price => 
                            price.PartnerId == partner.PartnerId && 
                            price.ProductId == product.ProductId
                        )
                }
        };
        return View(model);
    }
