    public ActionResult _AjaxLoading(string text) {
                var products = new List<Product>
                                   {
                                       new Product {ProductId = 1, ProductName = "b"}
                                   }.ToSelectListItem(m => m.ProductName, m => m.ProductId)
                                   .WithDefaultValue(1, "abc");
                return new JsonResult { Data = products } };
    }
